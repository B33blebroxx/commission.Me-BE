using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommissionMe.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    ProfilePic = table.Column<string>(type: "text", nullable: true),
                    Rates = table.Column<string>(type: "text", nullable: true),
                    Experience = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true),
                    StyleIds = table.Column<int[]>(type: "integer[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    PostImg = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ProfileId = table.Column<int>(type: "integer", nullable: false),
                    StyleId = table.Column<int>(type: "integer", nullable: false),
                    Private = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StyleName = table.Column<string>(type: "text", nullable: true),
                    ProfileId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Styles_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PostId = table.Column<int>(type: "integer", nullable: false),
                    TagId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Email", "Experience", "Name", "ProfilePic", "Rates", "StyleIds", "Uid" },
                values: new object[,]
                {
                    { 1, "Troy... Troy Barnes?... Barnes comma Troy??", "tbone@greendale.edu", "3-5 Years", "Troy Barnes", "https://i.redd.it/3fbg5y6884351.jpg", "$200-300", new[] { 1, 3, 19 }, "V9gg3039YHROMJ6pH8tPD84Qrzh2" },
                    { 2, "It's called 'Showbusiness,' not 'Friendbusiness...'", "CoolAbedProductions@greendale.edu", "6-9 Years", "Abed Nadir", "https://spacecrip.files.wordpress.com/2012/04/abed.png?w=640", "300+", new[] { 2, 3, 4, 6, 8, 15, 17 }, "WDnlUTXgAxfAgRjrNebr6dppvC83" },
                    { 3, "That's nice!", "ShirleysSandwiches@greendale.edu", "3-5 Years", "Shirley Bennett", "https://assets.mycast.io/characters/shirley-bennett-6527587-normal.jpg?1659645717", "$200-300", new[] { 3, 5, 12, 14 }, "KC1UeRhu8ATnVAodM8uMDIi9Brh2" }
                });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "ProfileId", "StyleName" },
                values: new object[,]
                {
                    { 1, null, "Landscapes" },
                    { 2, null, "Pop" },
                    { 3, null, "Commercial" },
                    { 4, null, "Abstract" },
                    { 5, null, "Realism" },
                    { 6, null, "Impressionism" },
                    { 7, null, "Photorealism" },
                    { 8, null, "Portrait" },
                    { 9, null, "Expressionism" },
                    { 10, null, "Minimalism" },
                    { 11, null, "Surrealism" },
                    { 12, null, "Digital" },
                    { 13, null, "Graffiti" },
                    { 14, null, "Conceptual" },
                    { 15, null, "Anime/Toon" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "TagName" },
                values: new object[,]
                {
                    { 1, "Bright" },
                    { 2, "Photography" },
                    { 3, "Logo" },
                    { 4, "Dark" },
                    { 5, "Portrait" },
                    { 6, "Abstract" },
                    { 7, "Surreal" },
                    { 8, "Beauty" },
                    { 9, "Scary" },
                    { 10, "Peaceful" },
                    { 11, "Realistic" },
                    { 12, "Cartoon" },
                    { 13, "Anime" },
                    { 14, "Bold" },
                    { 15, "Minimal" },
                    { 16, "Folksy" },
                    { 17, "Modern" },
                    { 18, "Classic" },
                    { 19, "Retro" },
                    { 20, "Urban" },
                    { 21, "Futuristic" },
                    { 22, "Sci-Fi" },
                    { 23, "Fantasy" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "Description", "PostImg", "Private", "ProfileId", "StyleId", "Title" },
                values: new object[,]
                {
                    { 1, null, "https://media.wired.com/photos/5a13e367eceb990b7e519957/master/w_2560%2Cc_limit/Alice-X-Zhang.jpg", false, 2, 2, "Best Friends" },
                    { 2, null, "https://images.fineartamerica.com/images/artworkimages/mediumlarge/2/abed-the-astronaut-community-joseph-oland.jpg", false, 1, 1, "Up" },
                    { 3, null, "https://obiruskenobi.files.wordpress.com/2013/11/greendale_final.jpg", false, 2, 2, "The Greendale Dead" },
                    { 4, null, "https://images.theconversation.com/files/296052/original/file-20191008-128681-ngzwqb.jpg?ixlib=rb-1.1.0&rect=15%2C20%2C929%2C926&q=20&auto=format&w=320&fit=clip&dpr=2&usm=12&cs=strip", true, 2, 2, "Arts!" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ProfileId",
                table: "Posts",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_PostId",
                table: "PostTags",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_PostId_TagId",
                table: "PostTags",
                columns: new[] { "PostId", "TagId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagId",
                table: "PostTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_ProfileId",
                table: "Styles",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
