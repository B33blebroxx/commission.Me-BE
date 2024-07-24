using CommissionMe.Models;
using Microsoft.EntityFrameworkCore;

namespace CommissionMe.Controllers
{
    public static class StylesApi
    {
        public static void Map(WebApplication app)
        {
            //Get all styles
            app.MapGet("/styles", (CommissionMeDbContext db) =>
            {
                var styles = db.Styles;
                if (styles == null)
                {
                    return (Results.NotFound());
                }

                return Results.Ok(styles);
            });

            //Add a style
            app.MapPost("/styles", (CommissionMeDbContext db, Style style) =>
            {
                db.Styles.Add(style);
                db.SaveChanges();
                return Results.Created($"/styles/{style.Id}", style);
            });

            //Delete a style
            app.MapDelete("/styles/{id}", (CommissionMeDbContext db, int id) =>
            {
                var style = db.Styles.SingleOrDefault(s => s.Id == id);
                if (style == null)
                {
                    return Results.NotFound();
                }
                db.Styles.Remove(style);
                db.SaveChanges();
                return Results.Ok();
            });
        }
    }
}
