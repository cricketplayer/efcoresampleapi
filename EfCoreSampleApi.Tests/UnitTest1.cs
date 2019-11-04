using EfCoreSampleApi.Application.Services;
using EFCoreSampleApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EfCoreSampleApi.Tests
{
    public class PersonServiceTest
    {
        DbContextOptions<PersonContext> _options;
        public PersonServiceTest()
        {
            //Arrange
            _options = new DbContextOptionsBuilder<PersonContext>()
                .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
                .Options;
        }

        [Fact]
        public async Task When_Creating_Person_Adds_To_Database()
        {
            using (var context = new PersonContext(_options))
            {
                var service = new PersonService(context);
                await service.CreatePerson("Abraca Dabra");
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new PersonContext(_options))
            {
                var personInDb = await context.Persons.Where(x => x.Name == "Abraca Dabra").SingleOrDefaultAsync();
                Assert.Equal("Abraca Dabra", personInDb.Name);
            }
        }

        [Theory]
        [InlineData("Abu abu")]
        [InlineData("bingo")]
        [InlineData("banjo")]
        public async Task Same_Test_As_Above(string name)
        {
           

            using (var context = new PersonContext(_options))
            {
                var service = new PersonService(context);
                await service.CreatePerson(name);
            }

            // Use a separate instance of the context to verify correct data was saved to database
            using (var context = new PersonContext(_options))
            {
                //Assert.Equal(1, context.Persons.Count()); // can't use this check now that there are more than one persons
                var personInDb = await context.Persons.Where(x => x.Name == name).SingleOrDefaultAsync();
                Assert.Equal(name, personInDb.Name);
            }
        }
    }
}
