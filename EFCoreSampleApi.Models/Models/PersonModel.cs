namespace EFCoreSampleApi.Models
{
    public class PersonModel
    {
        public string Name { get; set; }
    }

    public class BlogModel
    {
        public int PersonId { get; set; }
        public int BlogId { get; set; }
        public string Url { get; set; }
    }

    public class PostModel
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
