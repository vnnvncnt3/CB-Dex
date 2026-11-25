namespace Cardbooth.Client.Services;

public interface IAvailabilityService
{
    Task<IReadOnlySet<DateOnly>> GetUnavailableDatesAsync(int year, int month);
}