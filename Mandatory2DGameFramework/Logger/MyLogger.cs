using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.Logger
{
    public class MyLogger
    {
        // Singleton TraceSource instance
        private TraceSource ts;
        private TraceListener? listener;

        private static MyLogger instance = new MyLogger();
        public static MyLogger Instance { get { return instance; } }

        // Private constructor for singleton pattern
        private MyLogger()
        {
            ts = new TraceSource("Game Logger", SourceLevels.All);
            ts.Switch = new SourceSwitch("Game Logger", SourceLevels.All.ToString());
        }

        // Configuration methods
        public void AddListener(TraceListener listener)
        {
            ts.Listeners.Add(listener);
        }
        public void RemoveListener(TraceListener listener)
        {
            ts.Listeners.Remove(listener);
        }
        public void SetDefaultLevel(SourceLevels level)
        {
            ts.Switch.Level = level;
        }
        public void SetDebugLogging()
        {
            if (listener == null)
            {
                listener = new ConsoleTraceListener();
                ts.Listeners.Add(listener);
            }
        }
        public void RemoveDebugLogging()
        {
            if (listener != null)
            {
                ts.Listeners.Remove(listener);
                listener = null;
            }
        }

        // Logging methods
        public void LogInfo(string message)
        {
            ts.TraceEvent(TraceEventType.Information, 42, message);
        }

        public void LogError(string message)
        {
            ts.TraceEvent(TraceEventType.Error, 42, message);
        }

        public void LogWarning(string message)
        {
            ts.TraceEvent(TraceEventType.Warning, 42, message);
        }

        public void LogCritical(string message)
        {
            ts.TraceEvent(TraceEventType.Critical, 42, message);
        }
    }
}
