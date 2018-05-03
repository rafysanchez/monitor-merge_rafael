using System;
using System.Runtime.Serialization;
using Prodesp.Gsnet.Core.TO.Response;

namespace Prodesp.Monitor.TO.Response.Item
{
    [Serializable]
    [DataContract(Name = "ItemListResponse", Namespace = "Prodesp.Monitor.TO.Response.Item")]
    public class ItemListResponse : ListResponse<ItemListResponseData>
    {
    }
}
