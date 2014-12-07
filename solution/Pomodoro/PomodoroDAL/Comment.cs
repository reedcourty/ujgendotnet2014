using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroDAL
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }

        [Key, ForeignKey("Entry")]
        public int EntryId { get; set; }

        public Entry Entry { get; set; }
    }

}
