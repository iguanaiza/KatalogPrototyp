﻿namespace KatalogPrototyp.Data.Models
{
    public class BookBookSpecialTag
    {
        public int BookId { get; set; }
        public Book? Book { get; set; }

        public int BookSpecialTagId { get; set; }
        public BookSpecialTag? BookSpecialTag { get; set; }
    }
}
