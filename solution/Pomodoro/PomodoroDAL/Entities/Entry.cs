using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int Azonosito { get; set; }

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

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public override string ToString()
        {
            return String.Format("Entry[Azonosito = {0}, Timestamp = {1}, Description = {2}, Tags({3})]", this.Azonosito, this.Timestamp, this.Description, this.Tags.Count);
        }
    }
}
