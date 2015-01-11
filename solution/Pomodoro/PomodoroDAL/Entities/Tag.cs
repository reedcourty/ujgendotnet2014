using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroDAL
{
    [KnownType(typeof(ProjectTag))]
    [KnownType(typeof(PomodoroTag))]
    [DataContract(IsReference = true)]
    public class Tag
    {
        //[DataMember]
        //public int Id { get; set; }

        [Key]
        [DataMember]
        public string TagName { get; set; }

        // LazyLoading:
        // public virtual ICollection<Entry> Entries { get; private set; }

        // LazyLoading off:
        [DataMember]
        public ICollection<Entry> Entries { get; private set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public override string ToString()
        {
            int count;

            if (this.Entries != null)
            {
                count = this.Entries.Count;
            }
            else
            {
                count = 0;
            }
            
            return String.Format("Tag[TagName = {0}, Entries({1})]", this.TagName, count);
        }
    }
}
