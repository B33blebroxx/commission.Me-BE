using Microsoft.EntityFrameworkCore;
using CommissionMe.Models;

namespace CommissionMe.Controllers
{
    public static class PostTagsApi
    {
        public static void Map(WebApplication app)
        {
            // Add a tag to a post
            app.MapPost("/posts/{postId}/tags/{tagId}", (CommissionMeDbContext db, int postId, int tagId) =>
            {
                var post = db.Posts.SingleOrDefault(p => p.Id == postId);
                if (post == null)
                {
                    return Results.NotFound();
                }

                var tag = db.Tags.SingleOrDefault(t => t.Id == tagId);
                if (tag == null)
                {
                    return Results.NotFound();
                }

                var postTag = new PostTag
                {
                    PostId = postId,
                    TagId = tagId
                };

                db.PostTags.Add(postTag);
                db.SaveChanges();
                return Results.Ok();
            });

            // Remove a tag from a post
            app.MapDelete("/posts/tags/{id}", (CommissionMeDbContext db, int id) =>
            {
                var postTag = db.PostTags.SingleOrDefault(pt => pt.Id == id);
                if (postTag == null)
                {
                    return Results.NotFound();
                }

                db.PostTags.Remove(postTag);
                db.SaveChanges();
                return Results.Ok();
            });

            // Get all tags for a post
            app.MapGet("/posts/{postId}/tags", (CommissionMeDbContext db, int postId) =>
            {
                var post = db.Posts.SingleOrDefault(p => p.Id == postId);
                if (post == null)
                {
                    return Results.NotFound();
                }

                var postTags = db.PostTags
                    .Where(pt => pt.PostId == postId)
                    .Select(pt => new { pt.Id, pt.PostId, pt.TagId })
                    .ToList();

                return Results.Ok(postTags);
            });
        }
    }
}
