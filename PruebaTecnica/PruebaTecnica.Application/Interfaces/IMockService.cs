using PruebaTecnica.Domain.Entities;
using System.Collections.Generic;

namespace PruebaTecnica.Application.Interfaces
{
    public interface IMockService
    {
        List<Position> GetPositions(int rowCount);
        List<Employee> GetEmployees(int rowCount);
        List<Author> GetAuthors(int rowCount);
        List<Book> GetBooks(int rowCount);

        List<Position> SeedPositions(int rowCount);
    }
}