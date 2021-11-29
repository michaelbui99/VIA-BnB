﻿using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class GuestResponseType
    {
        /// <summary>
        /// GraphQL response container containing the queried residence. 
        /// </summary>
        /// <value></value>
        [JsonProperty("validateGuestLogin")]
        public Guest Guest { get; set; }
    }
}