namespace Service.Contracts
{
    public interface ISerilogService
    {
        Task<string> GetLogsAsync();
        Task<string> GetLogsByDayAsync(DateTime date);
        Task DeleteTodayLogsAsync();
        Task DeleteLogsByDayAsync(DateTime date);
    }
}
