using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Request;

namespace Prodesp.Monitor.TO.Request.ParamProg
{
    [Serializable]
    [DataContract(Name = "ParamProgSingleRequest", Namespace = "Prodesp.Monitor.TO.Request.ParamProg")]
    public class ParamProgSingleRequest : SingleRequest<ParamProgSingleRequestData>
    {
    }
}
