using Microsoft.EntityFrameworkCore;
using CommissionMe.Models;

namespace CommissionMe.Controllers
{
    public static class ProfilesApi
    {
        public static void Map(WebApplication app)
        {
            //Get all profiles
            app.MapGet("/profiles", (CommissionMeDbContext db) =>
            {
                var profiles = db.Profiles;
                if (profiles == null)
                {
                    return (Results.NotFound());
                }

                return Results.Ok(profiles);
            });

            //Get profile details
            app.MapGet("/profiles/{id}", (CommissionMeDbContext db, int id) =>
            {
                var profile = db.Profiles.Where(pr => pr.Id == id);
                if (profile.Count() == 0 || profile == null)
                {
                    return Results.NotFound();
                }
                return (Results.Ok(profile));
            });

            //Create a profile
            app.MapPost("/profiles", (CommissionMeDbContext db, Profile profile) =>
            {
                db.Profiles.Add(profile);
                db.SaveChanges();
                return Results.Created($"/profiles/{profile.Id}", profile);
            });
        }
    }
}
