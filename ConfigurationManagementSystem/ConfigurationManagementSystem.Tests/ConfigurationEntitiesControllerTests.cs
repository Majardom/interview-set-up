using ConfigurationManagementSystem.Controllers;
using ConfigurationManagementSystem.DbContext;
using ConfigurationManagementSystem.Repositories.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConfigurationManagementSystem.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAll_ReturnsAllConfigurationEntities()
        {
            //arrange
            var options = new DbContextOptions<AppDbContext>();
            var db = new AppDbContext(options);

            var sut = new ConfigurationEntitiesController(db);

            //act
            var result = sut.GetAll();

            //assert
            if (result is not OkObjectResult)
                Assert.Fail("Unsuccessfull response");

            var configurationEntities = ((OkObjectResult)result).Value as List<ConfigurationEntity>;

            Assert.That(configurationEntities?.Count, Is.EqualTo(2000));
        }
    }
}