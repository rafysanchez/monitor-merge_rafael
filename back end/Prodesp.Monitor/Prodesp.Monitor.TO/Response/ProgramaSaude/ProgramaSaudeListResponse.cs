using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Response;

namespace Prodesp.Monitor.TO.Response.ProgramaSaude
{
    [Serializable]
    [DataContract(Name = "ProgramaSaudeListResponse", Namespace = "Prodesp.Monitor.TO.Response.ProgramaSaude")]
    public class ProgramaSaudeListResponse : ListResponse<ProgramaSaudeListResponseData>
    {
    }
}
