using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroDAL
{
    [KnownType(typeof(ProjectTag))]
    [KnownType(typeof(PomodoroTag))]
    [DataContract]
    public class Tag
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string TagName { get; set; }

        // LazyLoading:
        // public virtual ICollection<Entry> Entries { get; private set; }

        // LazyLoading off:
        [DataMember]
        public ICollection<Entry> Entries { get; private set; }
    }
}
