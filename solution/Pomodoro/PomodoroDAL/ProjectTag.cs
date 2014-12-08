using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroDAL
{
    [DataContract]
    public class ProjectTag : PomodoroTag
    {
        [DataMember]
        public int Priority { get; set; }
    }

}
