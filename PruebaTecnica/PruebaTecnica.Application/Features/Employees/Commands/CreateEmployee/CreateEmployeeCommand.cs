using MediatR;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using PruebaTecnica.Application.Interfaces.Repositories;
using PruebaTecnica.Application.Wrappers;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Enums;
using System;

namespace PruebaTecnica.Application.Features.Employees.Commands.CreateEmployee
{
    public partial class CreateEmployeeCommand : IRequest<Response<Employee>>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmployeeTitle { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string EmployeeNumber { get; set; }
        public string Suffix { get; set; }
        public string Phone { get; set; }
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Response<Employee>>
    {
        private readonly IEmployeeRepositoryAsync _positionRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepositoryAsync positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<Response<Employee>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var position = _mapper.Map<Employee>(request);
            var entityPosition = await _positionRepository.AddAsync(position);
            return new Response<Employee>(entityPosition);
        }
    }
}
