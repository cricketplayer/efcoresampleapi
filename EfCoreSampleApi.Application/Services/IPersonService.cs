using System.Threading.Tasks;
using EFCoreSampleApi.Models;

namespace EfCoreSampleApi.Application.Services
{
    public interface IPersonService
    {
        Task<int> CreatePerson(string name);
        Task<int> CreatePersonBlog(int personId, BlogModel blogModel);
    }
}