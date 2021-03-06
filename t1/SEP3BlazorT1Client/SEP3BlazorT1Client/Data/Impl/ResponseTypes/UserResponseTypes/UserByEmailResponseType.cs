using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes.UserResponseTypes
{
    public class UserByEmailResponseType
    {
        [JsonProperty("userByEmail")] public User User { get; set; }
    }
}