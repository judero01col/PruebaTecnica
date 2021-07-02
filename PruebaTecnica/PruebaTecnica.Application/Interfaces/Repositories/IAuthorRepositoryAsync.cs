using System.Threading.Tasks;
using System.Collections.Generic;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Application.Parameters;
using PruebaTecnica.Application.Features.Authors.Queries.GetAuthors;

namespace PruebaTecnica.Application.Interfaces.Repositories
{
    public interface IAuthorRepositoryAsync : IGenericRepositoryAsync<Author>
    {
        Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedAuthorReponseAsync(GetAuthorsQuery requestParameters);
    }
}