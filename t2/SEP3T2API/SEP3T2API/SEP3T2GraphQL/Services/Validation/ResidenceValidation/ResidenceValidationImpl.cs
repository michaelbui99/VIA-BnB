﻿using System;
using System.Collections.Generic;
using System.Linq;
using SEP3T2GraphQL.Models;

namespace SEP3T2GraphQL.Services.Validation.ResidenceValidation
{
    public class ResidenceValidationImpl : IResidenceValidation
    {
        public bool IsValidAddress(Address address)
        {
            return address != null && 
                   ((address.Id != null && address.Id >= 0) &&
                    (!string.IsNullOrEmpty(address.StreetName)) &&
                    (!string.IsNullOrEmpty(address.HouseNumber)) &&
                    (!string.IsNullOrEmpty(address.CityName) && IsLettersOnly(address.CityName)) &&
                    (address.ZipCode is > 0 or <= 9999));
        }

        public bool IsValidRules(IList<Rule> rules)
        {
            return rules != null && (rules.All(rule => (rule.Id >= 0) && !string.IsNullOrEmpty(rule.Description)));
        }

        public bool IsValidFacilities(IList<Facility> facilities)
        {
            return facilities != null && (facilities.All(facility =>
                (facility.Id >= 0) && !string.IsNullOrEmpty(facility.Name)));
        }

        public bool IsValidResidence(Residence residence)
        {
            return (residence != null) &&
                   ((residence.Id != null && residence.Id >= 0) &&
                    (IsValidAddress(residence.Address)) &&
                    (!string.IsNullOrEmpty(residence.Description)) &&
                    (!string.IsNullOrEmpty(residence.Type)) &&
                    ((residence.AverageRating >= 0) &&
                     (residence.IsAvailable != null) &&
                     (residence.PricePerNight >= 0) &&
                     IsValidRules(residence.Rules) &&
                     (IsValidFacilities(residence.Facilities)) &&
                     (residence.AvailableFrom != null && residence.AvailableFrom >= DateTime.Now) &&
                     (residence.AvailableTo != null && residence.AvailableTo >= DateTime.Now)));
        }

        public bool IsLettersOnly(string arg)
        {
            return arg.Any(c => Char.IsLetter(c));
        }
        
    }
}