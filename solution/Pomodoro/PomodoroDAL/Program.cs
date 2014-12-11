using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\ProjectsV12;Initial Catalog=pomodoro;Integrated Security=True;MultipleActiveResultSets=True;";
            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {
                Console.WriteLine(String.Format("ProxyCreationEnabled: {0}", pctx.Configuration.ProxyCreationEnabled));

                // Entry entry = pctx.Entries.FirstOrDefault();
                Tag tag_test_001 = new PomodoroTag() { TagName = "Test 001", CreatedAt = DateTime.UtcNow };
                pctx.Tags.Add(tag_test_001);
                Tag tag_test_002 = new PomodoroTag() { TagName = "Test 002", CreatedAt = DateTime.UtcNow };
                pctx.Tags.Add(tag_test_002);
                Tag tag_test_003 = new ProjectTag() { TagName = "Test 003", CreatedAt = DateTime.UtcNow, Priority = 1 };
                pctx.Tags.Add(tag_test_003);

                Entry entry_001 = new Entry() { Timestamp = DateTime.UtcNow, Description = "Description 001" };
                entry_001.Tags.Add(tag_test_001);
                entry_001.Tags.Add(tag_test_002);
                pctx.Entries.Add(entry_001);

                Entry entry_002 = new Entry() { Timestamp = DateTime.UtcNow, Description = "Description 002" };
                entry_002.Tags.Add(tag_test_002);
                entry_002.Tags.Add(tag_test_003);
                pctx.Entries.Add(entry_002);

                Comment comment = new Comment() { Content = "Test comment", Entry = entry_001 };
                pctx.Comments.Add(comment);

                pctx.SaveChanges();
            }
        }
    }

}
