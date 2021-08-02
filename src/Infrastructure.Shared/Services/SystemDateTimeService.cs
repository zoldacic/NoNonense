﻿using NowWhat.Application.Interfaces.Services;
using System;

namespace NowWhat.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}