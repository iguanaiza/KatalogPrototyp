﻿namespace KatalogPrototyp.Data.Models
{
    public class BookBookGenre
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int BookGenreId { get; set; }
        public BookGenre BookGenre { get; set; }
    }
}
