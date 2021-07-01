using AutoMapper;
using MediatR;
using PruebaTecnica.Application.Interfaces;
using PruebaTecnica.Application.Interfaces.Repositories;
using PruebaTecnica.Application.Parameters;
using PruebaTecnica.Application.Wrappers;
using PruebaTecnica.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Authors.Queries.GetAuthors
{
    /// <summary>
    /// GetAllEmployeesQuery - handles media IRequest
    /// BaseRequestParameter - contains paging parameters
    /// To add filter/search parameters, add search properties to the body of this class
    /// </summary>
    public class GetAuthorsQuery : QueryParameter, IRequest<PagedResponse<IEnumerable<Entity>>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, PagedResponse<IEnumerable<Entity>>>
    {
        private readonly IAuthorRepositoryAsync _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IModelHelper _modelHelper;

        public GetAllAuthorsQueryHandler(IAuthorRepositoryAsync employeeRepository, IMapper mapper, IModelHelper modelHelper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _modelHelper = modelHelper;
        }

        public async Task<PagedResponse<IEnumerable<Entity>>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = request;

            //filtered fields security
            if (!string.IsNullOrEmpty(validFilter.Fields))
            {
                //limit to fields in view model
                validFilter.Fields = _modelHelper.ValidateModelFields<GetAuthorsViewModel>(validFilter.Fields);
            }

            if (string.IsNullOrEmpty(validFilter.Fields))
            {
                //default fields from view model
                validFilter.Fields = _modelHelper.GetModelFields<GetAuthorsViewModel>();
            }

            // query based on filter
            var entityEmployees = await _employeeRepository.GetPagedAuthorReponseAsync(validFilter);
            var data = entityEmployees.data;
            RecordsCount recordCount = entityEmployees.recordsCount;

            // response wrapper
            return new PagedResponse<IEnumerable<Entity>>(data, validFilter.PageNumber, validFilter.PageSize, recordCount);
        }
    }
}
