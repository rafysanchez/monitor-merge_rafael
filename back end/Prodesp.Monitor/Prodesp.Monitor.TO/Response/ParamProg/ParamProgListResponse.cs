using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Response;

namespace Prodesp.Monitor.TO.Response.ParamProg
{
    [Serializable]
    [DataContract(Name = "ParamProgListResponse", Namespace = "Prodesp.Monitor.TO.Response.ParamProg")]
    public class ParamProgListResponse : ListResponse<ParamProgListResponseData>
    {
    }
}
