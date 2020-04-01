using log4net;
using log4net.Config;
using log4net.Repository;
using System;
using System.Reflection;
using System.IO;
namespace VSeleniumFramework.Helpers
{
    public enum LogLevel
    {
        INFO, DEBUG, WARNING, ERROR
    }
    public static class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly ILoggerRepository logRepository = LogManager.GetRepository(Assembly.GetExecutingAssembly());
        
        static Logger()
        {
            GlobalContext.Properties["LogFileName"] = FileUtils.GetProperty("LogFile");
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        public static void Info(string typeName, string methodName)
        {
            log.Info(string.Format("[TYPE] {0} - [METHOD] {1}(..)",
                typeName, methodName));
        }

        public static void Error(string typeName, string methodName, Exception e)
        {
            log.Error(string.Format("[TYPE] {0} - [METHOD] {1}(..) - [EXCEPTION] {2}",
                typeName, methodName, e.GetType().Name));
        }
        public static void Info(string typeName,string objectName, string methodName)
        {
            log.Info(string.Format("[TYPE] {0} - [OBJECT NAME] {1} - [METHOD] {2}(..)",
                typeName, objectName, methodName));
        }

        public static void Info(string typeName, string objectName, string methodName, string param)
        {
            log.Info(string.Format("[TYPE] {0} - [OBJECT NAME] {1} - [METHOD] {2}(..) - [PARAM] {3}",
                typeName, objectName, methodName, param));
        }

        public static void Error(string typeName, string objectName, string methodName, string excpetion)
        {
            log.Error(string.Format("[TYPE] {0} - [OBJECT NAME] {1} - [METHOD] {2}(..) - [EXCEPTION] {3}",
                typeName, objectName, methodName, excpetion));
        }
    }
}
