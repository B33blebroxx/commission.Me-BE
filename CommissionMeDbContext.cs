using Microsoft.EntityFrameworkCore;
using CommissionMe.Models;
using Microsoft.Extensions.Options;
public class CommissionMeDbContext : DbContext
{
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Post> Posts { get; set; }

    public CommissionMeDbContext(DbContextOptions<CommissionMeDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Profile>().HasData(new Profile[]
        {
            new Profile { Id = 1, Name = "Troy Barnes", Email = "tbone@greendale.edu", Experience = "3-5 Years", Bio = "Troy... Troy Barnes?... Barnes comma Troy??", Image = "https://i.redd.it/3fbg5y6884351.jpg", Rates = "$200-300", Style = "Landscapes", Uid = "V9gg3039YHROMJ6pH8tPD84Qrzh2"},
            new Profile { Id = 2, Name = "Abed Nadir", Email = "CoolAbedProductions@greendale.edu", Experience = "6-9 Years", Bio = "It's called 'Showbusiness,' not 'Friendbusiness...'", Image = "https://spacecrip.files.wordpress.com/2012/04/abed.png?w=640", Rates = "300+", Style = "Pop", Uid = "WDnlUTXgAxfAgRjrNebr6dppvC83" },
            new Profile { Id = 3, Name = "Shirley Bennett", Email = "ShirleysSandwiches@greendale.edu", Experience = "3-5 Years", Bio = "That's nice!", Image = "https://assets.mycast.io/characters/shirley-bennett-6527587-normal.jpg?1659645717", Rates = "$200-300", Style = "Commercial", Uid = "KC1UeRhu8ATnVAodM8uMDIi9Brh2" }
        });

        modelBuilder.Entity<Post>().HasData(new Post[]
        {
            new Post { Id = 1, PostImg = "https://media.wired.com/photos/5a13e367eceb990b7e519957/master/w_2560%2Cc_limit/Alice-X-Zhang.jpg", Private = false, ProfileId = 2, Title = "Best Friends", Uid = "V9gg3039YHROMJ6pH8tPD84Qrzh2" },
            new Post { Id = 2, PostImg = "https://images.fineartamerica.com/images/artworkimages/mediumlarge/2/abed-the-astronaut-community-joseph-oland.jpg", Private = false, ProfileId = 1, Title = "Up", Uid = "WDnlUTXgAxfAgRjrNebr6dppvC83" },
            new Post { Id = 3, PostImg = "https://obiruskenobi.files.wordpress.com/2013/11/greendale_final.jpg", Private = false, ProfileId = 2, Title = "The Greendale Dead", Uid = "KC1UeRhu8ATnVAodM8uMDIi9Brh2" },
            new Post { Id = 4, PostImg = "https://images.theconversation.com/files/296052/original/file-20191008-128681-ngzwqb.jpg?ixlib=rb-1.1.0&rect=15%2C20%2C929%2C926&q=20&auto=format&w=320&fit=clip&dpr=2&usm=12&cs=strip", Private = true, ProfileId = 2, Title = "Arts!", Uid = "4Oqdg8mfh7TS8iz6zPCAu22GLGr1" }
        });
    }
}
