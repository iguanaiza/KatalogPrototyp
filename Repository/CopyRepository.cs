using KatalogPrototyp.Data;
using KatalogPrototyp.Data.Models;
using KatalogPrototyp.DataTransferObjects;
using KatalogPrototyp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace KatalogPrototyp.Repository
{
    public class CopyRepository : ICopyRepository
    {
        private readonly ApplicationDbContext _context;

        public CopyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CopyGetDto>> GetCopiesAsync()
        {
            return await _context.BookCopies
                .Include(c => c.Book).ThenInclude(b => b.BookAuthor)
                .Select(c => new CopyGetDto
                {
                    Id = c.Id,
                    Signature = c.Signature,
                    InventoryNum = c.InventoryNum,
                    Available = c.Available,
                    BookTitle = c.Book.Title,
                    BookImageUrl = c.Book.ImageUrl,
                    AuthorName = c.Book.BookAuthor.Surname + ", " + c.Book.BookAuthor.Name,
                    BookId = c.BookId
                })
                .ToListAsync();
        }

        public async Task<CopyGetDto?> GetCopyByIdAsync(int id)
        {
            return await _context.BookCopies
            .Include(c => c.Book).ThenInclude(b => b.BookAuthor)
            .Where(c => c.Id == id)
            .Select(c => new CopyGetDto
            {
                Id = c.Id,
                Signature = c.Signature,
                InventoryNum = c.InventoryNum,
                Available = c.Available,
                BookTitle = c.Book.Title,
                BookImageUrl = c.Book.ImageUrl,
                AuthorName = c.Book.BookAuthor.Surname + ", " + c.Book.BookAuthor.Name,
                BookId = c.BookId
            })
            .FirstOrDefaultAsync();
        }
    }
}
