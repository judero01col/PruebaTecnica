using PruebaTecnica.Application.Interfaces;
using System;

namespace PruebaTecnica.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
