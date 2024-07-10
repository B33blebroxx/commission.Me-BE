namespace CommissionMe.Controllers
{
    public class PostsApi
    {
        public static void Map(WebApplication app)
        {
            //Get all of a profile's posts
            app.MapGet("/profiles/{id}/all-posts", (CommissionMeDbContext db, int id) =>
            {
                var allPosts = db.Posts.Where(p => p.ProfileId == id).ToList();
                if (allPosts.Count() == 0)
                {
                    return Results.NotFound();
                }
                return Results.Ok(allPosts);
            });

            //Get a profile's public posts
            app.MapGet("/profiles/{id}/public-posts", (CommissionMeDbContext db, int id) =>
            {
                var publicPosts = db.Posts.Where(p =>p.ProfileId == id && !p.Private).ToList();
                if (publicPosts.Count() == 0)
                {
                    return Results.NotFound();
                }
                return Results.Ok(publicPosts);
            });
        }
    }
}
