using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using PruebaTecnica.Application.Exceptions;
using PruebaTecnica.Application.Interfaces.Repositories;
using PruebaTecnica.Application.Wrappers;
using PruebaTecnica.Domain.Entities;
using PruebaTecnica.Domain.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaTecnica.Application.Features.Books.Commands.CreateBook
{
    public partial class CreateBookCommand : IRequest<Response<Book>>
    {
        public Guid AuthorId { get; set; }
        [Required]
        public string Title { get; set; }
        public int Year { get; set; }
        [Required]
        public string Gender { get; set; }
        public int PageNumbers { get; set; }
    }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Response<Book>>
    {
        private readonly IBookRepositoryAsync _BookRepository;
        private readonly IAuthorRepositoryAsync _AuthorRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public CreateBookCommandHandler(IBookRepositoryAsync BookRepository, IAuthorRepositoryAsync AuthorRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _BookRepository = BookRepository;
            _AuthorRepository = AuthorRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public async Task<Response<Book>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);

            var Author = await _AuthorRepository.GetByIdAsync(book.AuthorId);

            if (Author != null)
            {
                var Counter = await _BookRepository.GetCounterAsync("AuthorId==@0", new object[] { book.AuthorId.ToString() });

                if (Counter < _appSettings.MaxBookAllow)
                {
                    var entityPosition = await _BookRepository.AddAsync(book);
                    return new Response<Book>(entityPosition);
                }
                else
                {
                    throw new ApiException("No es posible registrar el libro, se alcanzó el máximo permitido.");
                }
            }
            else
            {
                throw new ApiException("El autor no está registrado.");
            }
        }
    }
}
