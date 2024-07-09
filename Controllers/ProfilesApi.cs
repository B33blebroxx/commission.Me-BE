namespace CommissionMe.Controllers
{
    public static class ProfilesApi
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/profiles", (CommissionMeDbContext db) =>
            {
                var profiles = db.Profiles;
                if (profiles == null)
                {
                    return (Results.NotFound());
                }

                return Results.Ok(profiles);
            });
        }
    }
}
