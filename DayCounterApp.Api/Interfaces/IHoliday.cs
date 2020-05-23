namespace DayCounterApp.Api.Interfaces
{
    public interface IHoliday
    {
        int Id { get; set; }
        string Name { get; set; }
        int Type { get; set; }
    }
}
