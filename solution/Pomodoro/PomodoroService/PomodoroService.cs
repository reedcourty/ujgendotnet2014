using PomodoroDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PomodoroService
{
    public class PomodoroService : IPomodoroService
    {

        private PomodoroDAL.Methods methods = new Methods();

        /*
        public List<Tag> GetTags()
        {
            return new List<Tag>();
        }

        public List<Comment> GetComments()
        {
            return new List<Comment>();
        }


        public Tag GetTag(int id)
        {
            return new Tag();
        }

        */
        public Entry GetEntryById(int id) {
            return methods.GetEntryById(id);
        }

        /*
        public Comment GetComment(int id)
        {
            return new Comment();
        }

        */

        public Tag AddTag(string tagName)
        {
            return methods.AddNewTag(tagName);
        }

        /*
        public void AddEntry(Entry new_entry)
        {

        }


        public void AddComment(Comment new_comment)
        {

        }

        public void UpdateTag(int id, string tagname, List<int> entry_ids)
        {

        }
        */

        public string OldUpdateEntry(int entryId, string oldDescription, string newDescription)
        {
            return methods.UpdateEntry(entryId, oldDescription, newDescription);
        }

        public Entry UpdateEntry(Entry newEntry)
        {
            Entry result = null;
            try
            {
                result = methods.UpdateEntry(newEntry);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ce)
            {

                throw new FaultException(String.Format("The entry is already modified! :("));
            }
            catch (Exception ie)
            {
                throw new FaultException(String.Format("Something bad happend while we're trying to update the entry! :( ({0})", ie.Message));
            }
            return result;
        }

        /*
        public void UpdateComment(int id, string content, int entryId)
        {

        }
        */
        public void SaveEntry(DateTime timestamp, string description, string tags)
        {
            try
            {
                methods.AddNewEntryFromElements(timestamp, description, tags);
            }
            catch (Exception ie)
            {
                throw new FaultException(String.Format("Something bad happend while we're trying to save the entry! :( ({0})", ie.Message));
            }
        }

        public List<Entry> GetEntries()
        {
            List<Entry> result = new List<Entry>();

            try
            {
                result = methods.GetEntries();
            }
            catch (Exception ie)
            {

                throw new FaultException(String.Format("Something bad happend while we're trying to load entries! :( ({0})", ie.Message));
            }

            return result;
        }
    }
}
