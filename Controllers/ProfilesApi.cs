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

            //Update a profile
            app.MapPut("/profiles/{id}", (CommissionMeDbContext db, int id, Profile updatedProfile) =>
            {
                var profile = db.Profiles.Find(id);
                if (profile == null)
                {
                    return Results.NotFound();
                }
                profile.Name = updatedProfile.Name;
                profile.Email = updatedProfile.Email;
                profile.ProfilePic = updatedProfile.ProfilePic;
                profile.Rates = updatedProfile.Rates;
                profile.Styles = updatedProfile.Styles;
                profile.Experience = updatedProfile.Experience;
                profile.Bio = updatedProfile.Bio;

                db.SaveChanges();
                return Results.Ok(profile);
            });

            //Delete a profile and its posts
            app.MapDelete("/profiles/{id}", (CommissionMeDbContext db, int id) =>
            {
                var profile = db.Profiles.Find(id);
                if (profile == null)
                {
                    return Results.NotFound();
                }
                var posts = db.Posts.Where(p => p.ProfileId == id).ToList();
                db.Posts.RemoveRange(posts);
                db.Profiles.Remove(profile);
                db.SaveChanges();
                return Results.NoContent();
            });
        }
    }
}
