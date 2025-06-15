using System.ComponentModel.DataAnnotations;

namespace KatalogPrototyp.Data.Models
{
    public class BookSeries
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
