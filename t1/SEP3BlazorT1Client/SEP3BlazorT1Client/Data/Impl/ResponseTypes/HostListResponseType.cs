using System.Collections.Generic;
using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class HostListResponseType
    {
        [JsonProperty("allNotApprovedHost")] public IList<Host> Hosts { get; set; } = new List<Host>();
    }
}