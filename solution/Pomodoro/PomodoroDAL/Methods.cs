using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomodoroDAL
{
    public class Methods
    {
        private string connectionString = @"Data Source=(localdb)\ProjectsV12;Initial Catalog=pomodoro;Integrated Security=True;MultipleActiveResultSets=True;";
        //private string connectionString = @"Data Source=(notvalidlocaldb)\ProjectsV12;Initial Catalog=pomodoro;Integrated Security=True;MultipleActiveResultSets=True;";

        public Tag AddNewTag(string tagName)
        {
            Tag result = null;

            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {

                try
                {
                    Tag tag = new PomodoroTag() { TagName = tagName, CreatedAt = DateTime.UtcNow };
                    pctx.Tags.Add(tag);
                    pctx.SaveChanges();
                    result = pctx.Tags.Where(t => t.TagName == tagName).Single();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException due)
                {
                    string message = due.InnerException.InnerException.Message;

                    // "Violation of PRIMARY KEY constraint \'PK_dbo.Tags\'. Cannot insert duplicate key in object \'dbo.Tags\'. The duplicate key value is (Test 001).\r\nThe statement has be en terminated."
                    if (message.Contains(String.Format("The duplicate key value is ({0}).", tagName)))
                    {
                        result = pctx.Tags.Where(t => t.TagName == tagName).Single();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return result;
        }


        public void AddNewEntry(DateTime timestamp, string description, string tags)
        {

            char[] delimiterChars = { ',', ' ' };

            var tagList = tags.Split(delimiterChars).ToList().Distinct().ToList();
            tagList.Remove("");

            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {
                try
                {
                    Entry entry = new Entry() { Timestamp = timestamp, Description = description };

                    foreach (var tagName in tagList)
                    {
                        var tag = new Tag() { TagName = tagName };
                        var in_db_tag = pctx.Tags.Where(x => x.TagName == tag.TagName).FirstOrDefault();
                        if (in_db_tag != null)
                        {
                            entry.Tags.Add(in_db_tag);
                        }
                        else
                        {
                            entry.Tags.Add(tag);
                        }
                    }
                    pctx.Entries.Add(entry);
                    pctx.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

        }


        public List<Entry> GetEntries()
        {
            List<Entry> result = new List<Entry>();

            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {

                foreach (var item in pctx.Entries)
                {
                    pctx.Entry(item).Collection(x => x.Tags).Load();

                    ((IObjectContextAdapter)pctx).ObjectContext.Detach(item);

                    result.Add(item);
                }
            }

            return result;
        }


        public Entry GetEntry(int Id)
        {
            Entry entryInDb = null;
            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {
                entryInDb = pctx.Entries.Select(x => x).Where(x => x.Azonosito == Id).First();
                pctx.Entry(entryInDb).State = EntityState.Detached;
            }

            return entryInDb;
        }


        public void UpdateEntry(Entry newEntry)
        {
            Entry entryInDb = null;
            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {
                entryInDb = pctx.Entries.Select(x => x).Where(x => x.Azonosito == newEntry.Azonosito).First();
                pctx.Entry(entryInDb).State = EntityState.Detached;

                pctx.Entries.Attach(newEntry);
                pctx.Entry(newEntry).State = EntityState.Modified;

                pctx.SaveChanges();
            }
        }

        public string UpdateEntry(int entryId, string oldDescription, string newDescription)
        {
            string result = "OK";

            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {
                try
                {
                    Entry entryInDB = pctx.Entries.Where(x => x.Azonosito == entryId).FirstOrDefault();

                    if (entryInDB.Description == oldDescription)
                    {
                        entryInDB.Description = newDescription;
                        pctx.SaveChanges();
                    }
                    else
                    {
                        throw new System.Data.Entity.Infrastructure.DbUpdateConcurrencyException();
                    }
                }
                catch (Exception)
                {
                    result = "Something went wrong while trying to update the entry.";
                }

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
