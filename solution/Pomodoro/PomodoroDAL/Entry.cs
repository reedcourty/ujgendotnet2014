using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroDAL
{
    public class Entry
    {
        public Entry()
        {
            Tags = new List<Tag>();
        }

        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string Description { get; set; }

        // LazyLoading:
        // public virtual ICollection<Tag> Tags { get; private set; }

        // LazyLoading off:
        public ICollection<Tag> Tags { get; private set; }

        public Comment Comment { get; set; }
    }
}
