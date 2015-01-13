using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro.Utils
{
    public class Logger
    {
        private static TraceSource _default = new TraceSource("Pomodoro", SourceLevels.All);

        public static void TraceEvent(TraceEventType eventType, int id, string msg)
        {
            _default.TraceEvent(eventType, id, msg);
        }


        public static void Debug(string msg)
        {
            TraceEvent(TraceEventType.Verbose, 10, msg);
        }


        public static void Error(string msg)
        {
            TraceEvent(TraceEventType.Error, 50, msg);
        }


        public static void Info(string msg)
        {
            TraceEvent(TraceEventType.Information, 20, msg);
        }

    }
}
