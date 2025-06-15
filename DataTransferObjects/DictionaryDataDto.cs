﻿using KatalogPrototyp.Data.Models;

namespace KatalogPrototyp.DataTransferObjects
{
    public class DictionaryDataDto
    {
        public List<BookAuthor> Authors { get; set; }
        public List<BookPublisher> Publishers { get; set; }
        public List<BookSeries> Series { get; set; }
        public List<BookType> Types { get; set; }
        public List<BookCategory> Categories { get; set; }
        public List<BookGenre> Genres { get; set; }
        public List<BookSpecialTag> SpecialTags { get; set; }
        public List<BookCopy> Copies { get; set; }
    }
}
