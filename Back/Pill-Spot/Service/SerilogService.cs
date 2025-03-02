using Entities.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Service.Contracts;
using System.Text;

namespace Service
{
    public class SerilogService : ISerilogService
    {
        private readonly string _logDirectory;

        public SerilogService() => _logDirectory = "Logs";
        public async Task<string> GetLogsAsync()
        {
            if (!Directory.Exists(_logDirectory))
                throw new CustomDirectoryNotFoundException(_logDirectory);

            var latestLogFile = new DirectoryInfo(_logDirectory)
                .GetFiles("log-*.txt")
                .OrderByDescending(f => f.LastWriteTime)
                .FirstOrDefault();

            if (latestLogFile == null)
                throw new LogNotFoundException();

            using (var stream = new FileStream(latestLogFile.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(stream))
                return await reader.ReadToEndAsync();
        }
        public async Task<string> GetLogsByDayAsync(DateTime date)
        {
            if (!Directory.Exists(_logDirectory))
                throw new CustomDirectoryNotFoundException(_logDirectory);

            string logFileName = $"log-{date:yyyyMMdd}.txt";
            string logFilePath = Path.Combine(_logDirectory, logFileName);

            if (!File.Exists(logFilePath))
                throw new LogNotFoundException(date);

            using (var fileStream = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(fileStream, Encoding.UTF8))
                return await reader.ReadToEndAsync();
        }
        public async Task DeleteTodayLogsAsync()
        {
            if (!Directory.Exists(_logDirectory))
                throw new DirectoryNotFoundException("Log directory does not exist.");

            string logFileName = $"log-{DateTime.UtcNow:yyyyMMdd}.txt";
            string logFilePath = Path.Combine(_logDirectory, logFileName);

            if (!File.Exists(logFilePath))
                throw new FileNotFoundException($"No logs found for today.");

            Log.CloseAndFlush();

            await File.WriteAllTextAsync(logFilePath, string.Empty);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information("✅ Log file cleared and ready for new entries.");
        }
        public async Task DeleteLogsByDayAsync(DateTime date)
        {
            if (!Directory.Exists(_logDirectory))
                throw new DirectoryNotFoundException("Log directory does not exist.");

            string logFileName = $"log-{date:yyyyMMdd}.txt";
            string logFilePath = Path.Combine(_logDirectory, logFileName);

            if (!File.Exists(logFilePath))
                throw new FileNotFoundException($"No logs found for {date:yyyy-MM-dd}.");

            await Task.Run(() => File.Delete(logFilePath));
        }
    }
}
