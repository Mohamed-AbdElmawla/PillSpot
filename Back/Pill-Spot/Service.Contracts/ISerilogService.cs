using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
