using PruebaTecnica.Domain.Common;
using PruebaTecnica.Domain.Enums;
using System;

namespace PruebaTecnica.Domain.Entities
{
    public class Employee : AuditableBaseEntity
    {        
        public string FirstName { get; set; }     
        public string LastName { get; set; }
        public string EmployeeTitle { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string EmployeeNumber { get; set; }
        public string Suffix { get; set; }
        public string Phone { get; set; }
    }
}
