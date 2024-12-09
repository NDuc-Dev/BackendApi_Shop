using AdminApi.Interfaces;
using Serilog;
using Serilog.Events;
using Shared.Models;

namespace AdminApi.Services
{
    public class AuditLogService : IAuditLogServices
    {
        public async Task LogActionAsync(User user, string actionName, string? table = null, string? objId = null, string? exception = null, LogEventLevel? level = LogEventLevel.Information)
        {
            var logEntry = new AuditLog
            {
                ActorId = user.Id,
                ActorName = user.FullName,
                Action = actionName,
                AffectedTable = table,
                TimeStamp = DateTime.Now,
                ObjId = objId,
                Exception = exception
            };

            var logger = Log.ForContext("AuditLog", true);

            switch (level)
            {
                case LogEventLevel.Information:
                    logger.Information("Audit log: {@LogEntry}", logEntry);
                    break;
                case LogEventLevel.Warning:
                    logger.Warning("Audit log: {@LogEntry}", logEntry);
                    break;
                case LogEventLevel.Error:
                    logger.Error("Audit log: {@LogEntry}", logEntry);
                    break;
                default:
                    logger.Debug("Audit log: {@LogEntry}", logEntry);
                    break;
            }

            await Task.CompletedTask;
        }
    }
}