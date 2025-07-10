using KatalogPrototyp.DataTransferObjects;
using System.Threading.Tasks;

namespace KatalogPrototyp.Repository.IRepository
{
    public interface IBookRepository
    {
        public Task<IEnumerable<BookGetDto>> GetBooksAsync();
        public Task<BookGetDto?> GetBookByIdAsync(int id);
        public Task<IEnumerable<BookGetDto>> GetBooksByTagAsync(string tagName);
        public Task<IEnumerable<BookGetDto>> GetLekturyAsync();
        public Task<IEnumerable<BookGetDto>> GetPodrecznikiAsync();
    }
}
