using PruebaTecnica.Application.Features.Authors.Queries.GetAuthors;
using System;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnica.Application.Features.Books.Queries.GetBooks
{
    public class GetBooksViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        [Required]
        public string Gender { get; set; }
        public int PageNumbers { get; set; }
        public GetAuthorsViewModel Author { get; set; }
    }
}
