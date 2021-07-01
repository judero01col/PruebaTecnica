using AutoMapper;
using MediatR;
using PruebaTecnica.Application.Interfaces.Repositories;
using PruebaTecnica.Application.Wrappers;
using PruebaTecnica.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Authors.Commands.CreateAuthor
{
    public partial class CreateAuthorCommand : IRequest<Response<Author>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthCity { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
    }

    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Response<Author>>
    {
        private readonly IAuthorRepositoryAsync _positionRepository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorRepositoryAsync positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<Response<Author>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var position = _mapper.Map<Author>(request);
            var entityPosition = await _positionRepository.AddAsync(position);
            return new Response<Author>(entityPosition);
        }
    }
}