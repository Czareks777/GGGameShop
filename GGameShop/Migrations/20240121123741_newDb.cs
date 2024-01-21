using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GGameShop.Migrations
{
    /// <inheritdoc />
    public partial class newDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DevStudio = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    GameCategoryId = table.Column<int>(type: "int", nullable: false),
                    PriceSteam = table.Column<double>(type: "float", nullable: false),
                    PriceXbox = table.Column<double>(type: "float", nullable: false),
                    PricePS = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_GameCategories_GameCategoryId",
                        column: x => x.GameCategoryId,
                        principalTable: "GameCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GameCategories",
                columns: new[] { "Id", "Category" },
                values: new object[,]
                {
                    { 1, "FPS" },
                    { 2, "Strategy" },
                    { 3, "RPG" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "DevStudio", "GameCategoryId", "ImageUrl", "PricePS", "PriceSteam", "PriceXbox", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { 1, "After wiping out the gods of Mount Olympus, Kratos moves on to the frigid lands of Scandinavia, where he and his son must embark on an odyssey across a dangerous world of gods and monsters.", "Sony Interactive Entertainment", 3, "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\God_of_War_4_cover.jpg", 300.0, 250.0, 350.0, "God of War", null },
                    { 2, "Baldur's Gate 3 is a story-rich, party-based RPG set in the universe of Dungeons & Dragons, where your choices shape a tale of fellowship and betrayal, survival and sacrifice, and the lure of absolute power.", "Larian Studios", 3, "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\Baldur's_Gate_3_cover_art.jpg", 300.0, 250.0, 400.0, "Baldurs Gate 3", null },
                    { 3, "The Witcher 3: Wild Hunt is an action role-playing game with a third-person perspective. Players control Geralt of Rivia, a monster slayer known as a Witcher. Geralt walks, runs, rolls and dodges, and (for the first time in the series) jumps, climbs and swims.", "CDPR", 3, "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\Witcher_3_cover_art.jpg", 200.0, 150.0, 250.0, "The Witcher 3: Wild Hunt", null },
                    { 4, "The cataclysmic conclusion to the Total War: WARHAMMER trilogy is here. Rally your forces and step into the Realm of Chaos, a dimension of mind-bending horror where the very fate of the world will be decided. Will you conquer your Daemons… or command them?", "Creative Assembly", 2, "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\Total_War_Warhammer_3_cover_art.jpg", 350.0, 300.0, 310.0, "Total War Warhammer 3", null },
                    { 5, "Civilization VI is a turn-based strategy video game in which one or more players compete alongside computer-controlled AI opponents to grow their individual civilization from a small tribe to control the entire planet across several periods of development.", "Firaxis Games", 2, "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\Civilization_VI_cover_art.jpg", 150.0, 100.0, 200.0, "Civilization VI", null },
                    { 6, "Crusader Kings III is a grand strategy role-playing video game set in the Middle Ages, developed by Paradox Development Studio and published by Paradox Interactive as a sequel to Crusader Kings and Crusader Kings II.", "Paradox Development Studio", 2, "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\Crusader_Kings_III.jpg", 199.0, 200.0, 250.0, "Crusader Kings III", null },
                    { 7, "Apex Legends is a free-to-play battle royale-hero shooter game developed by Respawn Entertainment and published by Electronic Arts. It was released for PlayStation 4, Windows, and Xbox One in February 2019, for Nintendo Switch in March 2021, and for PlayStation 5 and Xbox Series X/S in March 2022.", "Respawn Entertainment", 1, "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\Apex_legends_cover.jpg", 250.0, 200.0, 300.0, "Apex Legends", null },
                    { 8, "The game pits two teams, Terrorists and Counter-Terrorists, against each other in different objective-based game modes. The most common game modes involve the Terrorists planting a bomb while Counter-Terrorists attempt to stop them, or Counter-Terrorists attempting to rescue hostages that the Terrorists have captured.", "Valve", 1, "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\CSGOcoverMarch2020.jpg", 300.0, 200.0, 250.0, "Counter-Strike: Global Offensive", null },
                    { 9, "Summaries. In this sequel to Doom (2016), Hell has taken Earth, so it's up to the Doom Slayer, the ultimate demon-killing machine created by a mystical force, to rip and tear the forces of Hell apart. However, Hell is not alone in this fight.", "id Software", 1, "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\Cover_Art_of_Doom_Eternal.png", 285.0, 199.0, 250.0, "DOOM Eternal", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GameCategoryId",
                table: "Games",
                column: "GameCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "GameCategories");
        }
    }
}
