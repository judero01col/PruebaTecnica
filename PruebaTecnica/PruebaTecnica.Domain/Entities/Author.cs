using System;
using System.Collections.Generic;
using PruebaTecnica.Domain.Common;

namespace PruebaTecnica.Domain.Entities
{
    public class Author : AuditableBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthCity { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        List<Book> Books { get; set; }
    }
}
