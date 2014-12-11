using SimpleMvvmToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroGUI.Models
{
    public class Entry : ModelBase<Entry>
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                NotifyPropertyChanged(e => e.Id);
            }
        }

        private DateTime timestamp;
        public DateTime Timestamp
        {
            get { return timestamp; }
            set
            {
                timestamp = value;
                NotifyPropertyChanged(e => e.Timestamp);
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyPropertyChanged(e => e.Description);
            }
        }

    }
}
