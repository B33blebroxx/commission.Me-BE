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
                    Image = table.Column<string>(type: "text", nullable: true),
                    Rates = table.Column<string>(type: "text", nullable: true),
                    Style = table.Column<string>(type: "text", nullable: true),
                    Experience = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    PostImg = table.Column<string>(type: "text", nullable: true),
                    ProfileId = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: true),
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

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Bio", "Email", "Experience", "Image", "Name", "Rates", "Style", "Uid" },
                values: new object[,]
                {
                    { 1, "Troy... Troy Barnes?... Barnes comma Troy??", "tbone@greendale.edu", "3-5 Years", "https://i.redd.it/3fbg5y6884351.jpg", "Troy Barnes", "$200-300", "Landscapes", "V9gg3039YHROMJ6pH8tPD84Qrzh2" },
                    { 2, "It's called 'Showbusiness,' not 'Friendbusiness...'", "CoolAbedProductions@greendale.edu", "6-9 Years", "https://spacecrip.files.wordpress.com/2012/04/abed.png?w=640", "Abed Nadir", "300+", "Pop", "WDnlUTXgAxfAgRjrNebr6dppvC83" },
                    { 3, "That's nice!", "ShirleysSandwiches@greendale.edu", "3-5 Years", "https://assets.mycast.io/characters/shirley-bennett-6527587-normal.jpg?1659645717", "Shirley Bennett", "$200-300", "Commercial", "KC1UeRhu8ATnVAodM8uMDIi9Brh2" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "PostImg", "Private", "ProfileId", "Title", "Uid" },
                values: new object[,]
                {
                    { 1, "https://media.wired.com/photos/5a13e367eceb990b7e519957/master/w_2560%2Cc_limit/Alice-X-Zhang.jpg", false, 2, "Best Friends", "V9gg3039YHROMJ6pH8tPD84Qrzh2" },
                    { 2, "https://images.fineartamerica.com/images/artworkimages/mediumlarge/2/abed-the-astronaut-community-joseph-oland.jpg", false, 1, "Up", "WDnlUTXgAxfAgRjrNebr6dppvC83" },
                    { 3, "https://obiruskenobi.files.wordpress.com/2013/11/greendale_final.jpg", false, 2, "The Greendale Dead", "KC1UeRhu8ATnVAodM8uMDIi9Brh2" },
                    { 4, "https://images.theconversation.com/files/296052/original/file-20191008-128681-ngzwqb.jpg?ixlib=rb-1.1.0&rect=15%2C20%2C929%2C926&q=20&auto=format&w=320&fit=clip&dpr=2&usm=12&cs=strip", true, 2, "Arts!", "4Oqdg8mfh7TS8iz6zPCAu22GLGr1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ProfileId",
                table: "Posts",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Profiles");
        }
    }
}
