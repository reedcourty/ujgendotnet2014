using Pomodoro.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
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


        public Comment AddNewComment(Comment newComment)
        {
            Comment result = null;
            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {
                try
                {
                    Comment comment = new Comment() { Content = newComment.Content };
                    var in_db_entry = pctx.Entries.Where(x => x.Id == newComment.Entry.Id).FirstOrDefault();

                    if (in_db_entry != null)
                    {
                        Logger.TraceEvent(TraceEventType.Verbose, 10, in_db_entry.ToString());
                        comment.Entry = in_db_entry;
                    }
                    else
                    {
                        throw new Exception(String.Format("There is no entry in DB with id {0}", newComment.Entry.Id));
                    }

                    result = pctx.Comments.Add(comment);
                    pctx.SaveChanges();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return result;
        }


        public Entry AddNewEntry(Entry newEntry)
        {
            Entry result = null;
            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {
                try
                {
                    Entry entry = new Entry() { Timestamp = newEntry.Timestamp, Description = newEntry.Description };

                    foreach (var entryTag in newEntry.Tags)
                    {
                        var tag = new Tag() { TagName = entryTag.TagName };
                        var in_db_tag = pctx.Tags.Where(x => x.TagName == tag.TagName).FirstOrDefault();

                        if (in_db_tag != null)
                        {
                            Console.WriteLine(in_db_tag);
                            Logger.TraceEvent(TraceEventType.Verbose, 10, in_db_tag.ToString());
                            entry.Tags.Add(in_db_tag);
                        }
                        else
                        {
                            entry.Tags.Add(tag);
                        }
                    }

                    result = pctx.Entries.Add(entry);
                    pctx.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
        }


        public Entry AddNewEntryFromElements(DateTime timestamp, string description, string tags)
        {
            Entry result = null;

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
                    result = pctx.Entries.Add(entry);
                    pctx.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return result;
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


        public List<Tag> GetTags()
        {
            List<Tag> result = new List<Tag>();

            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {
                foreach (var item in pctx.Tags)
                {
                    result.Add(item);
                }
            }
            return result;
        }


        public List<Comment> GetComments()
        {
            List<Comment> result = new List<Comment>();

            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {
                foreach (var item in pctx.Comments)
                {
                    result.Add(item);
                }
            }
            return result;
        }


        public Entry GetEntryById(int entryId)
        {
            Entry entryInDb = null;
            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {
                entryInDb = pctx.Entries.Select(x => x).Where(x => x.Id == entryId).First();
                pctx.Entry(entryInDb).State = EntityState.Detached;
            }
            return entryInDb;
        }


        public Entry UpdateEntry(Entry newEntry)
        {
            Entry result = null;
            Logger.TraceEvent(TraceEventType.Verbose, 10, newEntry.ToString());
            Entry entryInDb = null;
            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {
                entryInDb = pctx.Entries.Select(x => x).Where(x => x.Id == newEntry.Id).First();
                pctx.Entry(entryInDb).State = EntityState.Detached;

                pctx.Entries.Attach(newEntry);
                pctx.Entry(newEntry).State = EntityState.Modified;

                pctx.SaveChanges();
                result = pctx.Entries.Select(x => x).Where(x => x.Id == newEntry.Id).First();
            }
            return result;
        }


        public string UpdateEntry(int entryId, string oldDescription, string newDescription)
        {
            string result = "OK";

            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {
                try
                {
                    Entry entryInDB = pctx.Entries.Where(x => x.Id == entryId).FirstOrDefault();

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


        public void ClearDB()
        {
            using (PomodoroContext pctx = new PomodoroContext(connectionString))
            {
                # region Removing all comments
                try
                {
                    foreach (var currentComment in pctx.Comments.ToList<Comment>())
                    {
                        pctx.Comments.Remove(currentComment);
                    }

                    pctx.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                # endregion

                # region Removing all entries
                try
                {
                    foreach (var currentEntry in pctx.Entries.ToList<Entry>())
                    {
                        pctx.Entries.Remove(currentEntry);
                    }

                    pctx.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                # endregion

                # region Removing all tags
                try
                {
                    foreach (var currentTag in pctx.Tags.ToList<Tag>())
                    {
                        pctx.Tags.Remove(currentTag);
                    }

                    pctx.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                # endregion
            }
        }


        public void InitDB()
        {
            ClearDB();

            List<string> lines = new List<string>() {
                "The grass was greener", 
                "The light was brighter", 
                "The taste was sweeter", 
                "The nights of wonder", 
                "With friends surrounded", 
                "The dawn mist glowing", 
                "The water flowing", 
                "The endless river"};

            foreach (var item in lines)
            {
                Tag tag_001 = new Tag() { TagName = "Pink_Floyd" };
                Tag tag_002 = new Tag() { TagName = "High_Hopes" };
                Tag tag_003 = new Tag() { TagName = String.Format("Line_{0}", lines.IndexOf(item)) };

                Entry newEntry = new Entry() { Timestamp = DateTime.UtcNow, Description = item, Tags = new List<Tag>() { tag_001, tag_002, tag_003 } };

                newEntry = AddNewEntry(newEntry);

                Comment newComment = new Comment() { Content = "This is a comment.", Entry = newEntry };

                newComment = AddNewComment(newComment);
            }




        }


    }
}
