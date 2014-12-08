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
    }

}
