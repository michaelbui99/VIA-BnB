﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Repositories;
using SEP3T2GraphQL.Services.Validation;

namespace SEP3T2GraphQL.Services.Impl
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly CreateAddressValidator _createAddressValidator; 
        public AddressService(IAddressRepository addressRepository, CreateAddressValidator validator)
        {
            _addressRepository = addressRepository;
            _createAddressValidator = validator; 
        }

        public async Task<IEnumerable<Address>> GetAllAsync()
        {
            return await _addressRepository.GetAllAsync(); 
        }

        public async Task<Address> CreateAsync(Address address)
        {
            _createAddressValidator.Validate(address);
            return await _addressRepository.CreateAsync(address); 
        }
    }
}