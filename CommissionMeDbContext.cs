using Microsoft.EntityFrameworkCore;
using CommissionMe.Models;
using Microsoft.Extensions.Options;
public class CommissionMeDbContext : DbContext
{
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Style> Styles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PostTag> PostTags { get; set; }

    public CommissionMeDbContext(DbContextOptions<CommissionMeDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<PostTag>()
            .HasKey(pt => pt.Id);

        modelBuilder.Entity<PostTag>()
            .HasOne(pt => pt.Post)
            .WithMany(p => p.PostTags)
            .HasForeignKey(pt => pt.PostId);

        modelBuilder.Entity<PostTag>()
            .HasOne(pt => pt.Tag)
            .WithMany(t => t.PostTags)
            .HasForeignKey(pt => pt.TagId);

        modelBuilder.Entity<PostTag>()
            .HasIndex(pt => new { pt.PostId, pt.TagId })
            .IsUnique();

        modelBuilder.Entity<PostTag>()
            .HasIndex(pt => pt.PostId);

        modelBuilder.Entity<PostTag>()
        .HasIndex(pt => pt.TagId);

        modelBuilder.Entity<Profile>().HasData(new Profile[]
        {
            new Profile { Id = 1, Name = "Troy Barnes", Email = "tbone@greendale.edu", Experience = "3-5 Years", Bio = "Troy... Troy Barnes?... Barnes comma Troy??", ProfilePic = "https://i.redd.it/3fbg5y6884351.jpg", Rates = "$200-300", Uid = "V9gg3039YHROMJ6pH8tPD84Qrzh2", StyleIds = new List<int> { 1, 3, 19 } },
            new Profile { Id = 2, Name = "Abed Nadir", Email = "CoolAbedProductions@greendale.edu", Experience = "6-9 Years", Bio = "It's called 'Showbusiness,' not 'Friendbusiness...'", ProfilePic = "https://spacecrip.files.wordpress.com/2012/04/abed.png?w=640", Rates = "300+", Uid = "WDnlUTXgAxfAgRjrNebr6dppvC83", StyleIds = new List<int> { 2, 3, 4, 6, 8, 15, 17 } },
            new Profile { Id = 3, Name = "Shirley Bennett", Email = "ShirleysSandwiches@greendale.edu", Experience = "3-5 Years", Bio = "That's nice!", ProfilePic = "https://assets.mycast.io/characters/shirley-bennett-6527587-normal.jpg?1659645717", Rates = "$200-300", Uid = "KC1UeRhu8ATnVAodM8uMDIi9Brh2", StyleIds = new List<int> { 3, 5, 12, 14 } }
        });

        modelBuilder.Entity<Post>().HasData(new Post[]
        {
            new Post { Id = 1, PostImg = "https://media.wired.com/photos/5a13e367eceb990b7e519957/master/w_2560%2Cc_limit/Alice-X-Zhang.jpg", Private = false, ProfileId = 2, Title = "Best Friends", StyleId = 2 },
            new Post { Id = 2, PostImg = "https://images.fineartamerica.com/images/artworkimages/mediumlarge/2/abed-the-astronaut-community-joseph-oland.jpg", Private = false, ProfileId = 1, Title = "Up", StyleId = 1 },
            new Post { Id = 3, PostImg = "https://obiruskenobi.files.wordpress.com/2013/11/greendale_final.jpg", Private = false, ProfileId = 2, Title = "The Greendale Dead", StyleId = 2 },
            new Post { Id = 4, PostImg = "https://images.theconversation.com/files/296052/original/file-20191008-128681-ngzwqb.jpg?ixlib=rb-1.1.0&rect=15%2C20%2C929%2C926&q=20&auto=format&w=320&fit=clip&dpr=2&usm=12&cs=strip", Private = true, ProfileId = 2, Title = "Arts!", StyleId = 2 }
        });

        modelBuilder.Entity<Style>().HasData(new Style[]
        {
            new Style { Id = 1, StyleName = "Landscapes" },
            new Style { Id = 2, StyleName = "Pop" },
            new Style { Id = 3, StyleName = "Commercial" },
            new Style { Id = 4, StyleName = "Abstract" },
            new Style { Id = 5, StyleName = "Realism" },
            new Style { Id = 6, StyleName = "Impressionism" },
            new Style { Id = 7, StyleName = "Photorealism" },
            new Style { Id = 8, StyleName = "Portrait" },
            new Style { Id = 9, StyleName = "Expressionism" },
            new Style { Id = 10, StyleName = "Minimalism" },
            new Style { Id = 11, StyleName = "Surrealism" },
            new Style { Id = 12, StyleName = "Digital" },
            new Style { Id = 13, StyleName = "Graffiti" },
            new Style { Id = 14, StyleName = "Conceptual" },
            new Style { Id = 15, StyleName = "Anime/Toon" },
        });

        modelBuilder.Entity<Tag>().HasData(new Tag[]
        {
            new Tag { Id = 1, TagName = "Bright" },
            new Tag { Id = 2, TagName = "Photography" },
            new Tag { Id = 3, TagName = "Logo" },
            new Tag { Id = 4, TagName = "Dark" },
            new Tag { Id = 5, TagName = "Portrait" },
            new Tag { Id = 6, TagName = "Abstract" },
            new Tag { Id = 7, TagName = "Surreal" },
            new Tag { Id = 8, TagName = "Beauty" },
            new Tag { Id = 9, TagName = "Scary" },
            new Tag { Id = 10, TagName = "Peaceful" },
            new Tag { Id = 11, TagName = "Realistic" },
            new Tag { Id = 12, TagName = "Cartoon" },
            new Tag { Id = 13, TagName = "Anime" },
            new Tag { Id = 14, TagName = "Bold" },
            new Tag { Id = 15, TagName = "Minimal" },
            new Tag { Id = 16, TagName = "Folksy" },
            new Tag { Id = 17, TagName = "Modern" },
            new Tag { Id = 18, TagName = "Classic" },
            new Tag { Id = 19, TagName = "Retro" },
            new Tag { Id = 20, TagName = "Urban" },
            new Tag { Id = 21, TagName = "Futuristic" },
            new Tag { Id = 22, TagName = "Sci-Fi" },
            new Tag { Id = 23, TagName = "Fantasy" },
        });
    }
}
