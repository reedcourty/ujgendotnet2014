using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroDAL
{
    [DataContract]
    public class Comment
    {
        [DataMember]
        public int CommentId { get; set; }

        [DataMember]
        public string Content { get; set; }

        [DataMember]
        [Key, ForeignKey("Entry")]
        public int EntryId { get; set; }

        [DataMember]
        public Entry Entry { get; set; }
    }

}
