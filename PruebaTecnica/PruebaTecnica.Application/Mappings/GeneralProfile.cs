using AutoMapper;
using PruebaTecnica.Application.Features.Authors.Commands.CreateAuthor;
using PruebaTecnica.Application.Features.Authors.Queries.GetAuthors;
using PruebaTecnica.Application.Features.Employees.Commands.CreateEmployee;
using PruebaTecnica.Application.Features.Employees.Queries.GetEmployees;
using PruebaTecnica.Application.Features.Positions.Commands.CreatePosition;
using PruebaTecnica.Application.Features.Positions.Queries.GetPositions;
using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Position, GetPositionsViewModel>().ReverseMap();
            CreateMap<Employee, GetEmployeesViewModel>().ReverseMap();
            CreateMap<Author, GetAuthorsViewModel>().ReverseMap();

            CreateMap<CreatePositionCommand, Position>();
            CreateMap<CreateEmployeeCommand, Employee>();
            CreateMap<CreateAuthorCommand, Author>();
        }
    }

}
