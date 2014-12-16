using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroDAL
{
    public class Methods
    {
        private string connectionString = @"Data Source=(localdb)\ProjectsV12;Initial Catalog=pomodoro;Integrated Security=True;MultipleActiveResultSets=True;";


        public string AddNewTag(string tagName)
        {
            string result = "OK";

            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {
                Tag tag = new PomodoroTag() { TagName = tagName, CreatedAt = DateTime.UtcNow };
                pctx.Tags.Add(tag);
                try
                {
                    pctx.SaveChanges();
                    
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException due)
                {
                    string message = due.InnerException.InnerException.Message;

                    // "Violation of PRIMARY KEY constraint \'PK_dbo.Tags\'. Cannot insert duplicate key in object \'dbo.Tags\'. The duplicate key value is (Test 001).\r\nThe statement has be en terminated."
                    if (message.Contains(String.Format("The duplicate key value is ({0}).", tagName)))
                    {
                        result = String.Format("Tag with tagname '{0}' is already exists.", tagName);
                    }                    
                }
                catch (Exception e)
                {
                    result = e.ToString();
                }
            }
            return result;
        }


        public string AddNewEntry(DateTime timestamp, string description)
        {
            string result = "OK";

            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {
                Entry entry = new Entry() { Timestamp = timestamp, Description = description };
                pctx.Entries.Add(entry);
                pctx.SaveChanges();
            }
            return result;
        }


        public void DBInit()
        {
            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {

            }
        }
    }
}
