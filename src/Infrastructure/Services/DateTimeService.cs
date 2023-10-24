using CleanA.Application.Common.Interfaces;

namespace CleanA.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
