using InCar.Servicios.IlogService;
using NLog;
using ILogger = NLog.ILogger;

namespace InCar.Servicios
{
  public class LogService : ILogService
  {
    ILogger _log = LogManager.GetCurrentClassLogger();

    public LogService(IConfiguration configuration)
    {

    }

    public void WriteEventLog(String index, String action, String message, String type)
    {
      try
      {
        String logMessage = $"{index} => {action} - {message}";
        switch (type.ToLower())
        {
          case "debug":
            _log.Debug(logMessage);
            break;
          case "error":
            _log.Error(logMessage);
            break;
          case "info":
            _log.Info(logMessage);
            break;
          case "warn":
            _log.Warn(logMessage);
            break;
          case "fatal":
            _log.Fatal(logMessage);
            break;
          default:
            _log.Info($"Los parametros enviados no generan ninguna acción: Componente => {index}, Acción => {action}, Tipo de Log => {type}");
            break;
        }
      }
      catch (Exception ex)
      {
        _log.Error($"Log - WriteEventLog[{ex}]");
      }
    }
  }
}
