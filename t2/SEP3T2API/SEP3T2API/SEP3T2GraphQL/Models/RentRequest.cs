using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SEP3T2GraphQL.Models
{
    public class RentRequest
    {
        [Required, Range(1, Int32.MaxValue, ErrorMessage = "Id cannot be 0 or negative")]
        public int Id { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Number of guests must be 1 or above")]
        public int NumberOfGuests { get; set; }
        [Required]
        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public RentRequestStatus Status { get; set; }
        [Required]
        public Guest Guest { get; set; }
        [Required]
        public Residence Residence { get; set; }

        [Required]
        [JsonProperty("requestCreationDate")]
        public DateTime RequestCreationDate { get; set; }

        public decimal GetTotalPrice()
        {
            return (decimal) (GetRentPeriodInDays() * Residence.PricePerNight * NumberOfGuests); 
        }

        public int GetRentPeriodInDays()
        {
            return (EndDate - StartDate).Days;
        }
    }


    public enum RentRequestStatus
    {
        NOTANSWERED,
        NOTAPPROVED,
        APPROVED
    }
}