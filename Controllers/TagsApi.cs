namespace CommissionMe.Controllers
{
    public static class TagsApi
    {
        public static void Map(WebApplication app)
        {
            //Get all tags
            app.MapGet("/tags", (CommissionMeDbContext db) =>
            {
                var tags = db.Tags;
                if (tags == null)
                {
                    return (Results.NotFound());
                }

                return Results.Ok(tags);
            });

            //Add a tag
            app.MapPost("/tags", (CommissionMeDbContext db, Tag tag) =>
            {
                db.Tags.Add(tag);
                db.SaveChanges();
                return Results.Created($"/tags/{tag.Id}", tag);
            });

            //Delete a tag
            app.MapDelete("/tags/{id}", (CommissionMeDbContext db, int id) =>
            {
                var tag = db.Tags.SingleOrDefault(t => t.Id == id);
                if (tag == null)
                {
                    return Results.NotFound();
                }
                db.Tags.Remove(tag);
                db.SaveChanges();
                return Results.Ok();
            });
        }
    }
}
