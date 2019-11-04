using EFCoreSampleApi.Infrastructure;
using EFCoreSampleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EfCoreSampleApi.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly PersonContext _personContext;

        public PersonService(PersonContext personContext)
        {
            _personContext = personContext;
        }

        public async Task<int> CreatePerson(string name)
        {
            var person = _personContext.Persons.Add(new Person { Name = name });
            await _personContext.SaveChangesAsync();
            return person.Entity.Id;
        }

        public async Task<Person> GetPersonByName(string name)
        {
            var person = await _personContext.Persons.Where(x => x.Name == name ).SingleOrDefaultAsync();
            return person;
        }

        public async Task<int> CreatePersonBlog(int personId, BlogModel blogModel)
        {
            var person = await _personContext.Persons.Where(x => x.Id == personId).SingleOrDefaultAsync();
            if (person == null)
            {
                throw new Exception($"Person with id {personId} could not be found");
            }

            person.Blogs.Add(new Blog { PersonId = person.Id, Url = blogModel.Url });
            await _personContext.SaveChangesAsync();
            return person.Blogs.Where(x => x.Url == blogModel.Url).SingleOrDefault().BlogId;
        }
    }
}
