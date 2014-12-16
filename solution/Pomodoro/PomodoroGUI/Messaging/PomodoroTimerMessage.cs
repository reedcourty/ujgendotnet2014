using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroGUI.Messaging
{
    public class PomodoroTimerMessage
    {
        public enum MessageType
        {
            TimerStarted,
            TimerCountedDown
        }

        public MessageType Type { get; set; }

        public string Message { get; set; }

        public DateTime Timestamp { get; set; }

        public PomodoroTimerMessage()
        {

        }

        public PomodoroTimerMessage(MessageType type, string message, DateTime timestamp)
        {
            Type = type;
            Message = message;
            Timestamp = timestamp;
        }

        public PomodoroTimerMessage(MessageType type)
            : this(type, string.Empty, DateTime.UtcNow)
        {

        }

        public PomodoroTimerMessage(MessageType type, DateTime timestamp)
            : this(type, string.Empty, timestamp)
        {

        }
    }
}
