using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroDAL
{
    [DataContract]
    public class PomodoroTag : Tag
    {
        [DataMember]
        public DateTime CreatedAt { get; set; }
    }
}
