using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroGUI.Messaging
{
    public class PomodoroGeneralMessage
    {
        public enum MessageType
        {
            LoadEntryList
        }

        public MessageType Type { get; set; }

        public string Message { get; set; }

        public DateTime Timestamp { get; set; }

        public PomodoroGeneralMessage()
        {

        }

        public PomodoroGeneralMessage(MessageType type, string message, DateTime timestamp)
        {
            Type = type;
            Message = message;
            Timestamp = timestamp;
        }

        public PomodoroGeneralMessage(MessageType type)
            : this(type, string.Empty, DateTime.UtcNow)
        {

        }

        public PomodoroGeneralMessage(MessageType type, DateTime timestamp)
            : this(type, string.Empty, timestamp)
        {

        }
    }
}
