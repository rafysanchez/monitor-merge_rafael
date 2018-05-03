using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Request;

namespace Prodesp.Monitor.TO.Request.Parametros
{
    [Serializable]
    [DataContract(Name = "ParametrosSingleRequest", Namespace = "Prodesp.Monitor.TO.Request.Parametros")]
    public class ParametrosSingleRequest : SingleRequest<ParametrosSingleRequestData>
    {
    }
}
