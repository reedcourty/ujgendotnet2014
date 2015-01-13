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
        Entry GetEntryById(int id);


        [OperationContract]
        Tag AddTag(string tagName);

        
        [OperationContract]
        string OldUpdateEntry(int entryId, string oldDescription, string newDescription);


        [OperationContract]
        [FaultContract(typeof(FaultException))]
        Entry UpdateEntry(Entry newEntry);

        
        [OperationContract()]
        [FaultContract(typeof(FaultException))]
        void SaveEntry(DateTime timestamp, string description, string tags);


        [OperationContract]
        [FaultContract(typeof(FaultException))]
        List<Entry> GetEntries();
    }

}
