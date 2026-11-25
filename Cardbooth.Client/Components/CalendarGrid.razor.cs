using System.Globalization;
using Cardbooth.Client.Models;
using Cardbooth.Client.Services;
using Microsoft.AspNetCore.Components;

namespace Cardbooth.Client.Components;

public partial class CalendarGrid
{
    private static readonly string[] DayNames = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

    private enum DayState { Open, Selected, Unavailable, Past }

    private DateOnly _firstMonth;
    private DateOnly _visibleMonth;
    private DateOnly _earliestBookable;
    private IReadOnlySet<DateOnly> _unavailable = new HashSet<DateOnly>();
    private bool _loading;

    [Inject] private IAvailabilityService Availability { get; set; } = default!;

    [Parameter] public DateOnly? SelectedDate { get; set; }
    [Parameter] public EventCallback<DateOnly?> SelectedDateChanged { get; set; }

    private int LeadingBlanks => (int)_visibleMonth.DayOfWeek;
    private int DaysInMonth => DateTime.DaysInMonth(_visibleMonth.Year, _visibleMonth.Month);
    private bool CanGoPrevious => _visibleMonth > _firstMonth;

    protected override async Task OnInitializedAsync()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        _firstMonth = new DateOnly(today.Year, today.Month, 1);
        _visibleMonth = _firstMonth;
        _earliestBookable = today.AddDays(BookingRules.MinNoticeDays);

        await LoadMonthAsync();
    }

    private async Task LoadMonthAsync()
    {
        _loading = true;
        _unavailable = await Availability.GetUnavailableDatesAsync(_visibleMonth.Year, _visibleMonth.Month);
        _loading = false;
    }

    private Task PreviousMonthAsync() => ChangeMonthAsync(-1);

    private Task NextMonthAsync() => ChangeMonthAsync(1);

    private async Task ChangeMonthAsync(int delta)
    {
        _visibleMonth = _visibleMonth.AddMonths(delta);
        await LoadMonthAsync();
    }

    private async Task SelectAsync(DateOnly date)
    {
        SelectedDate = date;
        await SelectedDateChanged.InvokeAsync(date);
    }

    private DayState GetState(DateOnly date)
    {
        if (date < _earliestBookable) return DayState.Past;
        if (_unavailable.Contains(date)) return DayState.Unavailable;
        return date == SelectedDate ? DayState.Selected : DayState.Open;
    }

    // Full class strings on purpose: Tailwind only generates classes it can read as whole words.
    private static string DayClass(DayState state) => state switch
    {
        DayState.Selected => "bg-accent font-bold text-neutral-950 ring-2 ring-neutral-950",
        DayState.Open => "bg-white text-neutral-950 hover:bg-type-lightning-soft",
        DayState.Unavailable => "cursor-not-allowed bg-neutral-200 text-neutral-400 line-through",
        _ => "cursor-not-allowed text-neutral-300"
    };

    private static string Label(DateOnly date, DayState state)
    {
        var text = date.ToString("MMMM d, yyyy", CultureInfo.InvariantCulture);
        return state switch
        {
            DayState.Selected => $"{text}, selected",
            DayState.Open => $"{text}, available",
            DayState.Unavailable => $"{text}, unavailable",
            _ => $"{text}, not available"
        };
    }
}