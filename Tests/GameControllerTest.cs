using DataAccess;
using GGameShop.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Moq;

namespace GGameShop.Tests.Areas.Admin.Controllers
{
    public class GameCategoryControllerTests
    {
        [Fact]
        public void Index_ReturnsViewWithGameCategoryList()
        {
            // Arrange
            var dbMock = new Mock<ApplicationDbContext>();
            var controller = new GameCategoryController(dbMock.Object);

            var gameCategories = new List<GameCategory>
            {
                new GameCategory { Id = 1, Category = "Category1" },
                new GameCategory { Id = 2, Category = "Category2" }
            };

           

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.ViewData.Model);
            Assert.IsType<List<GameCategory>>(result.ViewData.Model);
            Assert.Equal(gameCategories, result.ViewData.Model);
        }
    }
}
