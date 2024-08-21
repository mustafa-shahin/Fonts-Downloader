using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public static class Logger
    {
        private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.json");

        public static void HandleError(string userMessage, Exception ex)
        {
            var logMessage = CreateLogMessage(userMessage, ex);
            AppendLogToFile(logMessage);
            MessageBox.Show(userMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static LogMessage CreateLogMessage(string message, Exception ex)
        {
            return new LogMessage
            {
                Msg = message,
                Data = new ErrorData
                {
                    ExceptionMessage = ex.Message,
                    ExceptionType = ex.GetType().FullName,
                    StackTrace = ex.StackTrace
                },
                EpochMs = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
                Level = "ERROR",
                Id = Guid.NewGuid().ToString()
            };
        }

        private static void AppendLogToFile(LogMessage logMessage)
        {
            var logEntries = new List<LogMessage>();

            // Read existing logs
            if (File.Exists(LogFilePath))
            {
                var existingLogs = File.ReadAllText(LogFilePath);
                if (!string.IsNullOrEmpty(existingLogs))
                {
                    logEntries = JsonSerializer.Deserialize<List<LogMessage>>(existingLogs);
                }
            }

            // Add the new log entry
            logEntries.Add(logMessage);

            // Write back to the file
            var json = JsonSerializer.Serialize(logEntries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(LogFilePath, json);
        }

    }

    public class LogMessage
    {
        public string Msg { get; set; }
        public ErrorData Data { get; set; }
        public long EpochMs { get; set; }
        public string Level { get; set; }
        public string Id { get; set; }
    }

    public class ErrorData
    {
        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
        public string StackTrace { get; set; }
    }
}
