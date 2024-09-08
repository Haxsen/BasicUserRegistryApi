using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRegistryApi.Controllers;
using UserRegistryApi.Models;

namespace UserRegistryApi.Tests.Controllers
{
    public class UsersControllerTests
    {
        [Fact]
        public async Task RegisterUser_ValidModel_ReturnsOkResult()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<UserRegistryContext>();
            builder.UseNpgsql("Host=localhost;Database=user_registry;Username=postgres;Password=hxn");
            var context = new UserRegistryContext(builder.Options);
            var controller = new UsersController(context);
            var model = new RegisterUserModel { username = "TestUser" };

            // Act
            var result = await controller.RegisterUser(model);

            // Assert
            Assert.IsType<OkObjectResult>(result);

            // Dispose the context
            await context.DisposeAsync();
        }

        [Fact]
        public async Task RegisterUser_InvalidModel_ThrowsDbUpdateException()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<UserRegistryContext>();
            builder.UseNpgsql("Host=localhost;Database=user_registry;Username=postgres;Password=hxn");
            var context = new UserRegistryContext(builder.Options);
            var controller = new UsersController(context);
            var model = new RegisterUserModel { username = null }; // invalid model

            // Act and Assert
            await Assert.ThrowsAsync<DbUpdateException>(async () =>
            {
                var result = await controller.RegisterUser(model);
            });

            // Dispose the context
            await context.DisposeAsync();
        }

        [Fact]
        public async Task RegisterUser_ValidModel_CreatesUserInDatabase()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<UserRegistryContext>();
            var context = new UserRegistryContext(builder.Options, true);
            var controller = new UsersController(context);
            var model = new RegisterUserModel { username = "TestUser" };

            // Act
            var result = await controller.RegisterUser(model);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Single(context.users);
        }
    }
}
