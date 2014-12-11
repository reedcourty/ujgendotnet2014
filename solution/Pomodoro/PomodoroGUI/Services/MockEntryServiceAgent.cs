using PomodoroDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroGUI.Services
{
    public class MockEntryServiceAgent : IEntryServiceAgent
    {
        public List<Entry> LoadEntries()
        {
            List<Entry> entries = new List<Entry>();

            Entry entry_001 = new Entry() { Id = 1, Comment = null, Description = "Description", Timestamp = DateTime.UtcNow };

            entries.Add(entry_001);

            return entries;
        }
    }
}
