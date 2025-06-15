using KatalogPrototyp.Components.Pages;
using KatalogPrototyp.Data.Models;
using KatalogPrototyp.DataTransferObjects;

namespace KatalogPrototyp.Repository.IRepository
{
    public interface IDictionaryRepository
    {
        Task<List<BookAuthor>> GetBookAuthorsAsync();
        Task<List<BookPublisher>> GetBookPublishersAsync();
        Task<List<BookSeries>> GetBookSeriesAsync();
        Task<List<BookType>> GetBookTypesAsync();
        Task<List<BookCategory>> GetBookCategoriesAsync();
        Task<List<BookGenre>> GetBookGenresAsync();
        Task<List<BookSpecialTag>> GetBookSpecialTagsAsync();
        Task<List<BookCopy>> GetBookCopiesAsync();
    }
}
