using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Logger
{
    public interface ILogger
    {
        void Debug(string format, params object[] objects);

        void Debug(string message);

        void Error(string format, params object[] objects);

        void Error(string message);

        void Fatal(string format, params object[] objects);

        void Fatal(string message);
    }
    public class Logger : ILogger
    {
        private static string _pathLogFile;
        public const string header = "INFO: {0} DETALLE: {1}";

        public Logger(string pathLogFile, string level)
        {
            switch (level)
            {
                case "INFORMATION":
                    _pathLogFile = pathLogFile;
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.With(new ThreadIdEnricher())
                        .WriteTo.File(_pathLogFile, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] <{ThreadId}> {Message:lj}{NewLine}{Exception}")
                        .MinimumLevel.Information()
                        .CreateLogger();
                    break;
                case "FATAL":
                    _pathLogFile = pathLogFile;
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.With(new ThreadIdEnricher())
                        .WriteTo.File(_pathLogFile, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] <{ThreadId}> {Message:lj}{NewLine}{Exception}")
                        .MinimumLevel.Fatal()
                        .CreateLogger();
                    break;
                case "WARNING":
                    _pathLogFile = pathLogFile;
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.With(new ThreadIdEnricher())
                        .WriteTo.File(_pathLogFile, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] <{ThreadId}> {Message:lj}{NewLine}{Exception}")
                        .MinimumLevel.Warning()
                        .CreateLogger();
                    break;
                case "ERROR":
                    _pathLogFile = pathLogFile;
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.With(new ThreadIdEnricher())
                        .WriteTo.File(_pathLogFile, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] <{ThreadId}> {Message:lj}{NewLine}{Exception}")
                        .MinimumLevel.Error()
                        .CreateLogger();
                    break;
                case "DEBUG":
                    _pathLogFile = pathLogFile;
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.With(new ThreadIdEnricher())
                        .WriteTo.File(_pathLogFile, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] <{ThreadId}> {Message:lj}{NewLine}{Exception}")
                        .MinimumLevel.Debug()
                        .CreateLogger();
                    break;
                default:
                    _pathLogFile = pathLogFile;
                    Log.Logger = new LoggerConfiguration()
                        .Enrich.With(new ThreadIdEnricher())
                        .WriteTo.File(_pathLogFile, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] <{ThreadId}> {Message:lj}{NewLine}{Exception}")
                        .MinimumLevel.Verbose()
                        .CreateLogger();
                    break;
            }
        }

        private static string GetStackTraceInfo()
        {
            var stackFrame = new StackTrace().GetFrame(2);
            string methodName = stackFrame.GetMethod().Name;
            string className = stackFrame.GetMethod().ReflectedType.FullName;
            return string.Format("Class: \"{0}\" Method: \"{1}\"", className, methodName);
        }

        public void Debug(string format, params object[] objects)
        {
            string location = GetStackTraceInfo();
            string message = string.Format(format, objects);
            Log.Debug(string.Format(header, location, message));
        }

        public void Debug(string message)
        {
            string location = GetStackTraceInfo();
            Log.Debug(string.Format(header, location, message));
        }

        public void Error(string format, params object[] objects)
        {
            string message = string.Format(format, objects);
            string location = GetStackTraceInfo();
            Log.Error(string.Format(header, location, message));
        }

        public void Error(string message)
        {
            string location = GetStackTraceInfo();
            Log.Error(string.Format(header, location, message));
        }

        public void Fatal(string format, params object[] objects)
        {
            string message = string.Format(format, objects);
            string location = GetStackTraceInfo();
            Log.Fatal(string.Format(header, location, message));
        }

        public void Fatal(string message)
        {
            string location = GetStackTraceInfo();
            Log.Fatal(string.Format(header, location, message));
        }
    }
}
