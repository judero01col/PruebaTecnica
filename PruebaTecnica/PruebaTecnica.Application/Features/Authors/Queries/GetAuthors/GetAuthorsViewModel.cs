using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Authors.Queries.GetAuthors
{
    public class GetAuthorsViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthCity { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}
