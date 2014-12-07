using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroDAL
{
    public abstract class Tag
    {
        public int Id { get; set; }

        public string TagName { get; set; }

        // LazyLoading:
        // public virtual ICollection<Entry> Entries { get; private set; }

        // LazyLoading off:
        public ICollection<Entry> Entries { get; private set; }
    }
}
