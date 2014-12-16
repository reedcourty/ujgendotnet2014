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


        public Entry GetEntry(int id) {
            return new Entry();
        }


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

        public string UpdateEntry(int entryId, string oldDescription, string newDescription)
        {
            return methods.UpdateEntry(entryId, oldDescription, newDescription);
        }

        /*
        public void UpdateComment(int id, string content, int entryId)
        {

        }
        */
        public string SaveEntry(DateTime timestamp, string description, string tags)
        {
            string result = "OK";

            methods.AddNewEntry(timestamp, description, tags);         

            return result;

        }

        public List<Entry> GetEntries()
        {
            return methods.GetEntries();
        }
    }
}
