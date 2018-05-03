using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Request;

namespace Prodesp.Monitor.TO.Request.ProgramaSaude
{
    [Serializable]
    [DataContract(Name = "ProgramaSaudeSingleRequest", Namespace = "Prodesp.Monitor.TO.Request.ProgramaSaude")]
    public class ProgramaSaudeSingleRequest : SingleRequest<ProgramaSaudeSingleRequestData>
    {
    }
}
