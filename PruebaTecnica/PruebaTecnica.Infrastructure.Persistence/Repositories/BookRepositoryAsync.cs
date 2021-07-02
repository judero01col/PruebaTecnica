using LinqKit;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Application.Features.Books.Queries.GetBooks;
using PruebaTecnica.Application.Interfaces;
using PruebaTecnica.Application.Interfaces.Repositories;
using PruebaTecnica.Application.Parameters;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Infrastructure.Persistence.Contexts;
using PruebaTecnica.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica.Infrastructure.Persistence.Repositories
{
    public class BookRepositoryAsync : GenericRepositoryAsync<Book>, IBookRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Book> _dataSet;
        private IDataShapeHelper<Book> _dataShaper;
        private readonly IMockService _mockData;
        
        public BookRepositoryAsync(ApplicationDbContext dbContext,
            IDataShapeHelper<Book> dataShaper,
            IMockService mockData) : base(dbContext)
        {
            _dbContext = dbContext;
            _dataSet = dbContext.Set<Book>();
            _dataShaper = dataShaper;
            _mockData = mockData;
        }

        public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedBookReponseAsync(GetBooksQuery requestParameter)
        {
            IQueryable<Book> result;

            var SearchField1 = requestParameter.Title;
            var SearchField2 = requestParameter.Gender;

            var pageNumber = requestParameter.PageNumber;
            var pageSize = requestParameter.PageSize;
            var orderBy = requestParameter.OrderBy;
            var fields = requestParameter.Fields;

            int recordsTotal, recordsFiltered;

            //int seedCount = 1000;
            //result = _mockData.GetEmployees(seedCount).AsQueryable();

            result = _dataSet.AsQueryable();

            // Count records total
            recordsTotal = result.Count();

            // filter data
            FilterByColumn(ref result, SearchField1, SearchField2);

            // Count records after filter
            recordsFiltered = result.Count();

            //set Record counts
            var recordsCount = new RecordsCount
            {
                RecordsFiltered = recordsFiltered,
                RecordsTotal = recordsTotal
            };

            // set order by
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                result = result.OrderBy(orderBy);
            }

            //limit query fields
            if (!string.IsNullOrWhiteSpace(fields))
            {
                result = result.Select<Book>("new(" + fields + ")");
            }
            // paging
            result = result
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            // retrieve data to list
            // var resultData = await result.ToListAsync();
            // Note: Bogus library does not support await for AsQueryable.
            // Workaround:  fake await with Task.Run and use regular ToList
            var resultData = await Task.Run(() => result.ToList());

            // shape data
            var shapeData = _dataShaper.ShapeData(resultData, fields);

            return (shapeData, recordsCount);
        }

        private void FilterByColumn(ref IQueryable<Book> positions, string SearchField1, string SearchField2)
        {
            if (!positions.Any())
                return;

            if (string.IsNullOrEmpty(SearchField2) && string.IsNullOrEmpty(SearchField1))
                return;

            var predicate = PredicateBuilder.New<Book>();

            if (!string.IsNullOrEmpty(SearchField1))
                predicate = predicate.And(p => p.Title.Contains(SearchField1.Trim()));

            if (!string.IsNullOrEmpty(SearchField2))
                predicate = predicate.And(p => p.Gender.Contains(SearchField2.Trim()));

            positions = positions.Where(predicate);
        }
    }
}
