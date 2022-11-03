using log4net;
using log4net.Repository;
using System.Reflection;
using System.Xml;

namespace WebNetSample.Core.CrossCuttingConcerns.Logging.Log4Net;

public class LoggerServiceBase
{
    private ILog _log;

    public LoggerServiceBase(string name)
    {
        var pathCombined = $"{Directory.GetCurrentDirectory()}/wwwroot/XmlData/log4net.config.xml";

        var xmlDocument = new XmlDocument();
        xmlDocument.Load(File.OpenRead(pathCombined));
            
        ILoggerRepository loggerRepository = LogManager.CreateRepository(Assembly.GetEntryAssembly(),
                typeof(log4net.Repository.Hierarchy.Hierarchy));
        log4net.Config.XmlConfigurator.Configure(loggerRepository, xmlDocument["log4net"]);

        _log = LogManager.GetLogger(loggerRepository.Name, name);
    }

    public void Info(object logMessage) =>
        _log.Info(logMessage); 

    public void Debug(object logMessage) =>
        _log.Debug(logMessage);

    public void Warn(object logMessage) =>
        _log.Warn(logMessage);

    public void Fatal(object logMessage) =>
        _log.Fatal(logMessage);   

    public void Error(object logMessage) =>
        _log.Error(logMessage);
}