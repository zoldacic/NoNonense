using NoNonense.Application.Interfaces.Services;
using System;

namespace NoNonense.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}