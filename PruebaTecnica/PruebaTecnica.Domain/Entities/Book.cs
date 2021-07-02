using System;
using System.ComponentModel.DataAnnotations;
using PruebaTecnica.Domain.Common;

namespace PruebaTecnica.Domain.Entities
{
    public class Book : AuditableBaseEntity
    {        
        public Guid AuthorId { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        [Required]
        public string Gender { get; set; }
        public int PageNumbers { get; set; }
        public Author Author { get; set; }
    }
}
