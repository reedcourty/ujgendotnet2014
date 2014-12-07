using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroDAL
{
    class PomodoroContext : DbContext
    {
        public DbSet<Entry> Entries { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<PomodoroTag> PomodoroTags { get; set; }

        public DbSet<ProjectTag> ProjectTags { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public PomodoroContext(string connectionString)
            : base(connectionString)
        {

        }

        public PomodoroContext()
        {

        }
    }

}
