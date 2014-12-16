using PomodoroDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PomodoroService
{
    [ServiceContract]
    public interface IPomodoroService
    {
        [OperationContract]
        List<Tag> GetTags();

        [OperationContract]
        List<Comment> GetComments();


        [OperationContract]
        Tag GetTag(int id);


        [OperationContract]
        Entry GetEntry(int id);


        [OperationContract]
        Comment GetComment(int id);


        [OperationContract]
        Tag AddTag(string tagName);


        [OperationContract]
        void AddEntry(Entry new_entry);


        [OperationContract]
        void AddComment(Comment new_comment);


        [OperationContract]
        void UpdateTag(int id, string tagname, List<int> entry_ids);


        [OperationContract]
        void UpdateEntry(int id, DateTime timestamp, string description,  List<int> tag_ids, int comment_id);


        [OperationContract]
        void UpdateComment(int id, string content, int entryId);

        [OperationContract]
        string SaveEntry(DateTime timestamp, string description, string tags);

        [OperationContract]

        List<Entry> GetEntries();
    }

}
