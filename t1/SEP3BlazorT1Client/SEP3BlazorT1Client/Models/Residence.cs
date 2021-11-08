﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Newtonsoft.Json;

namespace SEP3BlazorT1Client.Models
{
    public class Residence
    {   [JsonProperty("id")]
        public int Id { get; set; }
        [Required]
        [JsonProperty("address")]
        
        public Address Address { get; set; }
        [JsonProperty("description")]
        
        public string Description { get; set; }
        [Required]
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("averageRating")]
        public decimal AverageRating { get; set; }
        [JsonProperty("isAvailable")]
        public bool IsAvailable { get; set; }
        [Required]
        [JsonProperty("pricePerNight")]
        [Range(0, int.MaxValue)]
        public decimal PricePerNight { get; set; }
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        [Required]
        [JsonProperty("rules")]
        public IList<Rule> Rules { get; set; } = new List<Rule>();
        [Required]
        [JsonProperty("facilities")]
        public IList<Facility> Facilities { get; set; } = new List<Facility>();
        [JsonProperty("availableFrom")]
        public DateTime AvailableFrom { get; set; }
        [JsonProperty("availableTo")]
        public DateTime AvailableTo { get; set; }
        
        
        

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this); 
        }

        
    }
}