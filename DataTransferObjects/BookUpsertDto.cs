﻿using System.ComponentModel.DataAnnotations;

namespace KatalogPrototyp.DataTransferObjects
{
    public class BookUpsertDto
    {
        [Required(ErrorMessage = "Wprowadź tytuł książki (maksymalnie 200 znaków).")]
        [StringLength(200, ErrorMessage = "Niepoprawny tytuł: wpisz maksymalnie 200 znaków")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Wprowadź rok wydania książki (zakres 1000-2200.")]
        [Range(1000, 2200, ErrorMessage = "Niepoprawny rok: pisz cyfry z zakresu 1000-2200.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Wprowadź krótki opis książki (maksymalnie 800 znaków).")]
        [StringLength(800, ErrorMessage = "Niepoprawny opis: wpisz maksymalnie 800 znaków")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Wprowadź numer ISBN książki (13 cyfr we formacie XXX-XX-XXXX-XXX-X).")]
        [StringLength(17, ErrorMessage = "Niepoprawny ISBN: wprowadź 13 cyfr we formacie XXX-XX-XXXX-XXX-X.")]
        public string Isbn { get; set; } = null!;

        [Required(ErrorMessage = "Wprowadź ilość stron w książce (zakres 1-1500).")]
        [Range(1, 1500, ErrorMessage = "Niepoprawna ilość stron: wpisz cyfry z zakresu 1-1500.")]
        public int PageCount { get; set; }

        public bool IsVisible { get; set; }

        public string? ImageUrl { get; set; }

        public string? Subject { get; set; }

        public string? Class { get; set; }

        [Required(ErrorMessage = "Wybierz autora książki.")]
        public int BookAuthorId { get; set; }

        [Required(ErrorMessage = "Wybierz wydawcę książki.")]
        public int BookPublisherId { get; set; }

        [Required(ErrorMessage = "Wybierz do jakiej serii należy książka.")]
        public int BookSeriesId { get; set; }

        [Required(ErrorMessage = "Wybierz rodzaj książki.")]
        public int BookTypeId { get; set; }

        [Required(ErrorMessage = "Wybierz kategorię książki.")]
        public int BookCategoryId { get; set; }

        public List<int> BookGenreIds { get; set; } = null!;
        public List<int>? BookSpecialTagIds { get; set; }
        public List<int>? BookCopiesIds { get; set; }
    }
}
