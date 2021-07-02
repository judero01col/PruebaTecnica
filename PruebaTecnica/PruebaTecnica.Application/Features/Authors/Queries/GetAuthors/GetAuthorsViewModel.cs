using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Authors.Queries.GetAuthors
{
    public class GetAuthorsViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string BirthCity { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }
}
