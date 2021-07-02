using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Books.Queries.GetBooks
{
    public class GetBooksViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Gender { get; set; }
        public string PageNumbers { get; set; }
    }
}
