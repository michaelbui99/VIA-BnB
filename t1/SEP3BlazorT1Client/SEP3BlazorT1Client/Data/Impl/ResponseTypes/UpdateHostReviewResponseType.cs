﻿using Newtonsoft.Json;
using SEP3BlazorT1Client.Models;

namespace SEP3BlazorT1Client.Data.Impl.ResponseTypes
{
    public class UpdateHostReviewResponseType
    {
        
        [JsonProperty("updateHostReview")]
        
        public HostReview HostReview { get; set; }
    }
}