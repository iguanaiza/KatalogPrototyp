using KatalogPrototyp.DataTransferObjects;

namespace KatalogPrototyp.Repository.IRepository
{
    public interface ICopyRepository
    {
        public Task<IEnumerable<CopyGetDto>> GetCopiesAsync();
        public Task<CopyGetDto?> GetCopyByIdAsync(int id);
    }
}
