

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;



namespace DataAccess

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<GameCategory> GameCategories { get; set; }
        public DbSet<Game> Games { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<GameCategory>().HasData(
                new GameCategory { Id = 1, Category = "FPS" },
                new GameCategory { Id = 2, Category = "Strategy" },
                new GameCategory { Id = 3, Category = "RPG" }
                );

            builder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Title = "God of War",
                    Description = "After wiping out the gods of Mount Olympus," +
                " Kratos moves on to the frigid lands of Scandinavia," +
                " where he and his son must embark on an odyssey across a dangerous world of gods and monsters.",
                    DevStudio = "Sony Interactive Entertainment",
                    GameCategoryId = 3,
                    PriceSteam = 250,
                    PricePS = 300,
                    PriceXbox = 350,
                    ImageUrl = "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\God_of_War_4_cover.jpg"
                },
            new Game
            {
                Id = 2,
                Title = "Baldurs Gate 3",
                Description = "Baldur's Gate 3 is a story-rich, party-based RPG set in the universe of Dungeons & Dragons," +
                " where your choices shape a tale of fellowship and betrayal," +
                " survival and sacrifice, and the lure of absolute power.",
                DevStudio = "Larian Studios",
                GameCategoryId = 3,
                PriceSteam = 250,
                PricePS = 300,
                PriceXbox = 400,
                ImageUrl = "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\Baldur's_Gate_3_cover_art.jpg"
            },
                new Game
                {
                    Id = 3,
                    Title = "The Witcher 3: Wild Hunt",
                    Description = "The Witcher 3: Wild Hunt is an action role-playing game with a third-person perspective." +
                " Players control Geralt of Rivia, a monster slayer known as a Witcher. Geralt walks, runs, rolls and dodges, and (for the first time in the series) jumps" +
                ", climbs and swims.",
                    DevStudio = "CDPR",
                    GameCategoryId = 3,
                    PriceSteam = 150,
                    PricePS = 200,
                    PriceXbox = 250,
                    ImageUrl = "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\Witcher_3_cover_art.jpg"
                },
                new Game
                {
                    Id = 4,
                    Title = "Total War Warhammer 3",
                    Description = "The cataclysmic conclusion to the Total War: WARHAMMER trilogy is here." +
                " Rally your forces and step into the Realm of Chaos," +
                " a dimension of mind-bending horror where the very fate of the world will be decided." +
                " Will you conquer your Daemons… or command them?",
                    DevStudio = "Creative Assembly",
                    GameCategoryId = 2,
                    PriceSteam = 300,
                    PricePS = 350,
                    PriceXbox = 310,
                    ImageUrl = "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\Total_War_Warhammer_3_cover_art.jpg"
                },
                new Game
                {
                    Id = 5,
                    Title = "Civilization VI",
                    Description = "Civilization VI is a turn-based strategy video game in which one or more players compete alongside" +
                " computer-controlled AI opponents to grow their individual civilization from a small tribe to control the entire planet" +
                " across several periods of development.",
                    DevStudio = "Firaxis Games",
                    GameCategoryId = 2,
                    PriceSteam = 100,
                    PricePS = 150,
                    PriceXbox = 200,
                    ImageUrl = "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\Civilization_VI_cover_art.jpg"
                },
                new Game
                {
                    Id = 6,
                    Title = "Crusader Kings III",
                    Description = "Crusader Kings III is a grand strategy role-playing video game set in the Middle Ages, developed by Paradox Development Studio and published by Paradox Interactive" +
                " as a sequel to Crusader Kings and Crusader Kings II.",
                    DevStudio = "Paradox Development Studio",
                    GameCategoryId = 2,
                    PriceSteam = 200,
                    PricePS = 199,
                    PriceXbox = 250,
                    ImageUrl = "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\Crusader_Kings_III.jpg"
                },
                new Game
                {
                    Id = 7,
                    Title = "Apex Legends",
                    Description = "Apex Legends is a free-to-play battle royale-hero shooter game" +
                " developed by Respawn Entertainment and published by Electronic Arts. It was released for PlayStation 4," +
                " Windows, and Xbox One in February 2019, for Nintendo Switch in March 2021, and for PlayStation 5 and Xbox Series X/S in March 2022.",
                    DevStudio = "Respawn Entertainment",
                    GameCategoryId = 1,
                    PriceSteam = 200,
                    PricePS = 250,
                    PriceXbox = 300,
                    ImageUrl = "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\Apex_legends_cover.jpg"
                },
                new Game { Id = 8, Title = "Counter-Strike: Global Offensive", Description = "The game pits two teams, Terrorists and Counter-Terrorists, against each other in different objective-based game modes. The most common game modes involve the Terrorists planting a bomb while Counter-Terrorists attempt to stop them, or Counter-Terrorists attempting to rescue hostages that the Terrorists have captured.", DevStudio = "Valve", GameCategoryId = 1, PriceSteam = 200, PriceXbox = 250, PricePS = 300, ImageUrl = "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\CSGOcoverMarch2020.jpg" },
                new Game { Id = 9, Title = "DOOM Eternal", Description = "Summaries. In this sequel to Doom (2016), Hell has taken Earth, so it's up to the Doom Slayer, the ultimate demon-killing machine created by a mystical force, to rip and tear the forces of Hell apart. However, Hell is not alone in this fight.", DevStudio = "id Software", GameCategoryId = 1, PriceSteam = 199, PricePS = 285, PriceXbox = 250, ImageUrl = "C:\\Users\\czare\\source\\repos\\GameShop\\GameShop\\wwwroot\\images\\game\\Cover_Art_of_Doom_Eternal.png" }

                );
        }
    }
}
