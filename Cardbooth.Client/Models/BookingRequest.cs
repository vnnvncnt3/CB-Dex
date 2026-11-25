namespace Cardbooth.Client.Models;

public class BookingRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Organization { get; set; } = string.Empty;
    public string ContactNumber { get; set; } = string.Empty;
    public DateOnly EventDate { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Venue { get; set; } = string.Empty;
    public string CardDesign { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public BookingStatus Status { get; set; } = BookingStatus.Pending;
    public DateTime CreatedAt { get; set; }
}