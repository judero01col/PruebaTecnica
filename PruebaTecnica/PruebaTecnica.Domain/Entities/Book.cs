using System;
using PruebaTecnica.Domain.Common;

namespace PruebaTecnica.Domain.Entities
{
    public class Book : AuditableBaseEntity
    {        
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Gender { get; set; }
        public int PageNumbers { get; set; }
        public Author Author { get; set; }
    }
}
