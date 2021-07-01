using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using PruebaTecnica.Application.Interfaces;
using PruebaTecnica.Domain.Common;
using PruebaTecnica.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly ILoggerFactory _loggerFactory;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IDateTimeService dateTime,
            ILoggerFactory loggerFactory
            ) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _loggerFactory = loggerFactory;
        }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Author> Authors { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //var _mockData = this.Database.GetService<IMockService>();
            //var seedPositions = _mockData.SeedPositions(1000);
            //builder.Entity<Position>().HasData(seedPositions);

            //builder.Entity<Employee>().HasData(new Employee[]
            //{
            //    new Employee
            //    {
            //        Id = new Guid("5D5C4AAC-936B-4E54-B8CF-897130230816"),
            //        FirstName = "FirstName" ,                   
            //        LastName = "LastName",
            //        EmployeeTitle = "EmployeeTitle",
            //        DOB = new DateTime(2020, 08, 3),
            //        Email = "judero01@gmail.com",
            //        Gender = Domain.Enums.Gender.Male,
            //        EmployeeNumber = "123",
            //        Suffix = "Suffix",
            //        Phone="Phone",
            //        CreatedBy ="sfs",
            //        Created = new DateTime(2020, 08, 3),
            //        LastModifiedBy="sdsd",
            //        LastModified =new DateTime(2020, 08, 3)
            //    },
            //    new Employee
            //    {
            //        Id = new Guid("5D5C4AAC-936B-4E54-B8CF-897130230817"),
            //        FirstName = "FirstName" ,                    
            //        LastName = "LastName",
            //        EmployeeTitle = "EmployeeTitle",
            //        DOB = new DateTime(2020, 08, 3),
            //        Email = "judero01@gmail.com",
            //        Gender = Domain.Enums.Gender.Male,
            //        EmployeeNumber = "123",
            //        Suffix = "Suffix",
            //        Phone="Phone",
            //        CreatedBy ="sfs",
            //        Created = new DateTime(2020, 08, 3),
            //        LastModifiedBy="sdsd",
            //        LastModified =new DateTime(2020, 08, 3)
            //    }
            //});

            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }
}
