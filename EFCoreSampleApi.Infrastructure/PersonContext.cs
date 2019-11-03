using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFCoreSampleApi.Infrastructure
{
    public class PersonContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=.\SQLEXPRESS;Database=PersonDB;Trusted_Connection=True;");
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
    }
    public class Blog
    {
        public int PersonId { get; set; }
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
