using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class RentRequestIdResponseType
    {
        [JsonProperty("rentRequestById")] public RentRequest RentRequest { get; set; }
    }
}