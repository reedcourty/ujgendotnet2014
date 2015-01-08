using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroDAL.Entities
{
    [DataContract]
    public class Dummy
    {
        [DataMember]
        public int DummyAzonosito { get; set; }

        [DataMember]
        public string DummyStringField { get; set; }
    }
}
