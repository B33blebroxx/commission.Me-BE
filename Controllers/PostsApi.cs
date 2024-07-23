using CommissionMe.Models;
using Microsoft.EntityFrameworkCore;

namespace CommissionMe.Controllers
{
    public class PostsApi
    {
        public static void Map(WebApplication app)
        {
            //Get all of a profile's posts
            app.MapGet("/profiles/{id}/all-posts", (CommissionMeDbContext db, int id) =>
            {
                var allPosts = db.Posts.Where(p => p.ProfileId == id).Include(p => p.Style).Include(p => p.PostTags).ToList();
                if (allPosts.Count() == 0)
                {
                    return Results.NotFound();
                }
                return Results.Ok(allPosts);
            });

            //Get a profile's public posts
            app.MapGet("/profiles/{id}/public-posts", (CommissionMeDbContext db, int id) =>
            {
                var publicPosts = db.Posts.Where(p =>p.ProfileId == id && !p.Private).Include(p => p.Style).Include(p => p.PostTags).ToList();
                if (publicPosts.Count() == 0)
                {
                    return Results.NotFound();
                }
                return Results.Ok(publicPosts);
            });

            //Get a single post
            app.MapGet("/profiles/posts/{id}", (CommissionMeDbContext db, int id) =>
            {
                var post = db.Posts.Include(p => p.Style).Include(p => p.PostTags).SingleOrDefault(p => p.Id == id);
                if (post != null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(post);
            });

            //Create a post
            app.MapPost("/profile/posts/", (CommissionMeDbContext db, Post post) =>
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return Results.Created($"profiles/posts/{post.Id}", post);
            });

            //Delete a post
            app.MapDelete("/profile/posts/{id}", (CommissionMeDbContext db, int id) =>
            {
                var post = db.Posts.SingleOrDefault(p => p.Id == id);
                if (post == null)
                {
                    return Results.NotFound();
                }
                db.Posts.Remove(post);
                db.SaveChanges();
                return Results.NoContent();
            });

            //Update a post
            app.MapPut("/profile/posts/{id}", (CommissionMeDbContext db, int id, Post post) =>
            {
                var existingPost = db.Posts.SingleOrDefault(p => p.Id == id);
                if (existingPost == null)
                {
                    return Results.NotFound();
                }
                existingPost.Title = post.Title;
                existingPost.PostImg = post.PostImg;
                existingPost.Description = post.Description;
                existingPost.StyleId = post.StyleId;
                existingPost.Private = post.Private;
                db.SaveChanges();
                return Results.NoContent();
            });


        }
    }
}
