using PruebaTecnica.Application.Features.Books.Queries.GetBooks;
using PruebaTecnica.Application.Parameters;
using PruebaTecnica.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Interfaces.Repositories
{
    public interface IBookRepositoryAsync : IGenericRepositoryAsync<Book>
    {
        Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedBookReponseAsync(GetBooksQuery requestParameters);
    }
}