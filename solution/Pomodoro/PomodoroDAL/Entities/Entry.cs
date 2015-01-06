using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroDAL
{
    [DataContract(IsReference=true)]
    public class Entry
    {
        public Entry()
        {
            Tags = new List<Tag>();
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime Timestamp { get; set; }

        [DataMember]
        public string Description { get; set; }

        // LazyLoading:
        // public virtual ICollection<Tag> Tags { get; private set; }

        // LazyLoading off:
        [DataMember]
        public ICollection<Tag> Tags { get; set; }

        [DataMember]
        public Comment Comment { get; set; }
    }
}
