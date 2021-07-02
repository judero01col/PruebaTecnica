using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PruebaTecnica.Domain.Common;

namespace PruebaTecnica.Domain.Entities
{
    public class Author : AuditableBaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string BirthCity { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        List<Book> Books { get; set; }
    }
}
