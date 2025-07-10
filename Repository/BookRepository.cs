using KatalogPrototyp.Data;
using KatalogPrototyp.Data.Models;
using KatalogPrototyp.DataTransferObjects;
using KatalogPrototyp.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace KatalogPrototyp.Repository
{
#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region GETs
        public async Task<IEnumerable<BookGetDto>> GetBooksAsync()
        {

            return await _context.Books
                .Where(b => !b.IsDeleted)
                .Include(b => b.BookAuthor)
                .Include(b => b.BookPublisher)
                .Include(b => b.BookSeries)
                .Include(b => b.BookType)
                .Include(b => b.BookCategory)
                .Include(b => b.BookBookGenres).ThenInclude(bb => bb.BookGenre)
                .Include(b => b.BookBookSpecialTags).ThenInclude(bb => bb.BookSpecialTag)
                .OrderBy(b => b.BookAuthor.Surname)
                    .ThenBy(b=> b.Title)
                .Select(b => new BookGetDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Year = b.Year,
                    Description = b.Description,
                    Isbn = b.Isbn,
                    PageCount = b.PageCount,
                    IsDeleted= b.IsDeleted,
                    IsVisible = b.IsVisible,
                    ImageUrl = b.ImageUrl,
                    Subject = b.Subject,
                    Class = b.Class,
                    BookAuthorId = b.BookAuthor.Id,
                    BookAuthor = b.BookAuthor.Surname + ", " + b.BookAuthor.Name,
                    BookPublisherId = b.BookPublisher.Id,
                    BookPublisher = b.BookPublisher.Name,
                    BookSeriesId = b.BookSeries != null ? b.BookSeries.Id : (int?)null,
                    BookSeries = b.BookSeries != null ? b.BookSeries.Title : null,
                    BookCategoryId = b.BookCategory.Id,
                    BookCategory = b.BookCategory.Name,
                    BookTypeId = b.BookType.Id,
                    BookType = b.BookType.Title,
                    BookGenreIds = b.BookBookGenres.Select(bg => bg.BookGenre.Id).ToList(),
                    BookGenres = b.BookBookGenres.Select(bg => bg.BookGenre.Title).ToList(),
                    BookSpecialTags = b.BookBookSpecialTags.Select(bb => bb.BookSpecialTag.Title).ToList(),
                    CopyCount = b.BookCopies != null ? b.BookCopies.Count : 0,
                    AvailableCopyCount = b.BookCopies != null ? b.BookCopies.Count : 0
                })
                .ToListAsync();
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
        }

        public async Task<BookGetDto?> GetBookByIdAsync(int id)
        {
            var b = await _context.Books
                .Include(b => b.BookAuthor)
                .Include(b => b.BookPublisher)
                .Include(b => b.BookSeries)
                .Include(b => b.BookType)
                .Include(b => b.BookCategory)
                .Include(b => b.BookBookGenres).ThenInclude(bb => bb.BookGenre)
                .Include(b => b.BookBookSpecialTags).ThenInclude(bb => bb.BookSpecialTag)
                .Include(b => b.BookCopies)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (b == null) return null;

            return new BookGetDto
            {
                Id = b.Id,
                Title = b.Title,
                Year = b.Year,
                Description = b.Description,
                Isbn = b.Isbn,
                PageCount = b.PageCount,
                IsVisible = b.IsVisible,
                ImageUrl = b.ImageUrl,
                Subject = b.Subject,
                Class = b.Class,
                BookAuthor = b.BookAuthor.Surname + ", " + b.BookAuthor.Name,
                BookPublisher = b.BookPublisher.Name,
                BookSeries = b.BookSeries.Title,
                BookType = b.BookType.Title,
                BookCategory = b.BookCategory.Name,
                BookGenres = b.BookBookGenres.Select(g => g.BookGenre.Title).ToList(),
                BookSpecialTags = b.BookBookSpecialTags.Select(bb => bb.BookSpecialTag.Title).ToList(),
                BookCopies = b.BookCopies?
                            .Select(c => new CopyGetDto
                            {
                                Id = c.Id,
                                Signature = c.Signature,
                                Available = c.Available,
                                InventoryNum = c.InventoryNum
                            }).ToList(),
                CopyCount = b.BookCopies != null ? b.BookCopies.Count : 0,
                AvailableCopyCount = b.BookCopies != null ? b.BookCopies.Count : 0
            };
        }

        public async Task<IEnumerable<BookGetDto>> GetBooksByTagAsync(string tagName)
        {
            return await _context.Books
                .Include(b => b.BookAuthor)
                .Include(b => b.BookBookSpecialTags).Where(b => b.BookBookSpecialTags.Any(bb => bb.BookSpecialTag.Title == tagName))
                .Select(b => new BookGetDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Year = b.Year,
                    Description = b.Description,
                    Isbn = b.Isbn,
                    PageCount = b.PageCount,
                    IsDeleted = b.IsDeleted,
                    IsVisible = b.IsVisible,
                    ImageUrl = b.ImageUrl,
                    BookAuthor = b.BookAuthor.Surname + ", " + b.BookAuthor.Name,
                    BookSpecialTags = b.BookBookSpecialTags.Select(bb => bb.BookSpecialTag.Title).ToList(),
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<BookGetDto>> GetLekturyAsync()
        {
            const int CategoryId = 1;

            return await _context.Books
                 .Where(b => !b.IsDeleted && b.BookCategoryId == CategoryId)
                .Include(b => b.BookCategory)
                .Include(b => b.BookAuthor)
                .Include(b => b.BookPublisher)
                .Include(b => b.BookSeries)
                .Include(b => b.BookType)
                .Include(b => b.BookBookGenres).ThenInclude(bb => bb.BookGenre)
                .Include(b => b.BookCopies)
                .Include(b => b.BookBookSpecialTags).ThenInclude(bb => bb.BookSpecialTag)
                .OrderBy(b => b.Class)
                    .ThenBy(b => b.BookAuthor.Surname)
                        .ThenBy(b => b.Title)
                .Select(b => new BookGetDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Year = b.Year,
                    Description = b.Description,
                    Isbn = b.Isbn,
                    PageCount = b.PageCount,
                    IsDeleted = b.IsDeleted,
                    IsVisible = b.IsVisible,
                    ImageUrl = b.ImageUrl,
                    Subject = b.Subject,
                    Class = b.Class,
                    BookAuthorId = b.BookAuthor.Id,
                    BookAuthor = b.BookAuthor.Surname + ", " + b.BookAuthor.Name,
                    BookPublisherId = b.BookPublisher.Id,
                    BookPublisher = b.BookPublisher.Name,
                    BookSeriesId = b.BookSeries != null ? b.BookSeries.Id : (int?)null,
                    BookSeries = b.BookSeries != null ? b.BookSeries.Title : null,
                    BookCategoryId = b.BookCategory.Id,
                    BookCategory = b.BookCategory.Name,
                    BookTypeId = b.BookType.Id,
                    BookType = b.BookType.Title,
                    BookGenreIds = b.BookBookGenres.Select(bg => bg.BookGenre.Id).ToList(),
                    BookGenres = b.BookBookGenres.Select(bg => bg.BookGenre.Title).ToList(),
                    BookSpecialTags = b.BookBookSpecialTags.Select(bb => bb.BookSpecialTag.Title).ToList(),
                    CopyCount = b.BookCopies != null ? b.BookCopies.Count : 0
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<BookGetDto>> GetPodrecznikiAsync()
        {
            const int CategoryId = 2;

            return await _context.Books
                .Where(b => !b.IsDeleted && b.BookCategoryId == CategoryId)
                .Include(b => b.BookCategory)
                .Include(b => b.BookAuthor)
                .Include(b => b.BookPublisher)
                .Include(b => b.BookSeries)
                .Include(b => b.BookType)
                .Include(b => b.BookBookGenres).ThenInclude(bb => bb.BookGenre)
                .Include(b => b.BookCopies)
                .Include(b => b.BookBookSpecialTags).ThenInclude(bb => bb.BookSpecialTag)
                .OrderBy(b => b.Class)
                    .ThenBy(b => b.BookAuthor.Surname)
                        .ThenBy(b => b.Title)
                .Select(b => new BookGetDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    Year = b.Year,
                    Description = b.Description,
                    Isbn = b.Isbn,
                    PageCount = b.PageCount,
                    IsDeleted = b.IsDeleted,
                    IsVisible = b.IsVisible,
                    ImageUrl = b.ImageUrl,
                    Subject = b.Subject,
                    Class = b.Class,
                    BookAuthorId = b.BookAuthor.Id,
                    BookAuthor = b.BookAuthor.Surname + ", " + b.BookAuthor.Name,
                    BookPublisherId = b.BookPublisher.Id,
                    BookPublisher = b.BookPublisher.Name,
                    BookSeriesId = b.BookSeries != null ? b.BookSeries.Id : (int?)null,
                    BookSeries = b.BookSeries != null ? b.BookSeries.Title : null,
                    BookCategoryId = b.BookCategory.Id,
                    BookCategory = b.BookCategory.Name,
                    BookTypeId = b.BookType.Id,
                    BookType = b.BookType.Title,
                    BookGenreIds = b.BookBookGenres.Select(bg => bg.BookGenre.Id).ToList(),
                    BookGenres = b.BookBookGenres.Select(bg => bg.BookGenre.Title).ToList(),
                    BookSpecialTags = b.BookBookSpecialTags.Select(bb => bb.BookSpecialTag.Title).ToList(),
                    CopyCount = b.BookCopies != null ? b.BookCopies.Count : 0
                })
                .ToListAsync();
        }

        #endregion
    }
}
