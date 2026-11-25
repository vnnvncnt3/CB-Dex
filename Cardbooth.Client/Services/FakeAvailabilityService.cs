namespace Cardbooth.Client.Services;

public class FakeAvailabilityService : IAvailabilityService
{
    private static readonly HashSet<DateOnly> UnavailableDates = new()
    {
        new DateOnly(2026, 12, 5),
        new DateOnly(2026, 12, 12),
        new DateOnly(2026, 12, 20),
        new DateOnly(2026, 12, 24),
        new DateOnly(2026, 12, 25)
    };

    public Task<IReadOnlySet<DateOnly>> GetUnavailableDatesAsync(int year, int month)
    {
        IReadOnlySet<DateOnly> result = UnavailableDates
            .Where(d => d.Year == year && d.Month == month)
            .ToHashSet();

        return Task.FromResult(result);
    }
}