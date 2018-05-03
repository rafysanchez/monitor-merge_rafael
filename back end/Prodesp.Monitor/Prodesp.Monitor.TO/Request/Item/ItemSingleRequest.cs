using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Request;

namespace Prodesp.Monitor.TO.Request.Item
{
    [Serializable]
    [DataContract(Name = "ItemSingleRequest", Namespace = "Prodesp.Monitor.TO.Request.Item")]
    public class ItemSingleRequest : SingleRequest<ItemSingleRequestData>
    {
    }
}
