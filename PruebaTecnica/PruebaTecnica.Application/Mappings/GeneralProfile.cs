using AutoMapper;
using PruebaTecnica.Application.Features.Authors.Commands.CreateAuthor;
using PruebaTecnica.Application.Features.Authors.Queries.GetAuthors;
using PruebaTecnica.Application.Features.Books.Commands.CreateBook;
using PruebaTecnica.Application.Features.Books.Queries.GetBooks;
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
            CreateMap<CreatePositionCommand, Position>();
            CreateMap<Position, GetPositionsViewModel>().ReverseMap();
            
            CreateMap<CreateEmployeeCommand, Employee>();
            CreateMap<Employee, GetEmployeesViewModel>().ReverseMap();

            CreateMap<CreateAuthorCommand, Author>();
            CreateMap<Author, GetAuthorsViewModel>().ReverseMap();

            CreateMap<CreateBookCommand, Book>();
            CreateMap<Book, GetBooksViewModel>().ReverseMap();
        }
    }
}
