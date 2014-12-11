using PomodoroDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroGUI.Services
{
    public interface IEntryServiceAgent
    {
        List<Entry> LoadEntries();
    }
}
