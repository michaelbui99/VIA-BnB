﻿using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3T2GraphQL.Models;
using SEP3T2GraphQL.Services.Validation.HostValidation;

namespace SEP3T2GraphQL.Repositories.Impl
{
    public class HostRepositoryImpl : IHostRepository
    {
        
        private string uri = "http://localhost:8080";
        private readonly HttpClient client;
        private IHostValidation _hostValidation;

        public HostRepositoryImpl(IHostValidation hostValidation)
        {
            _hostValidation = hostValidation; 
            client = new HttpClient();
        }
        
        public async Task<Host> RegisterHostAsync(Host host)
        {
            System.Console.WriteLine($"{this} was passed args: {JsonSerializer.Serialize(host)}");
            
            string newHost = JsonSerializer.Serialize(host, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            Console.WriteLine(newHost);
            StringContent content = new StringContent(newHost, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync(uri + "/host", content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            Host h = JsonSerializer.Deserialize<Host>(await responseMessage.Content.ReadAsStringAsync(), new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            Console.WriteLine(h.ToString()); 
            return h;
        }


        public async Task<Host> GetHostByEmail(string email)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/host/{email}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            Host host = JsonSerializer.Deserialize<Host>(result, new JsonSerializerOptions(
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }));
            return host;
        }

        public async Task<Host> GetHostById(int id)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri + $"/host/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"$Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            Host host = JsonSerializer.Deserialize<Host>(result, new JsonSerializerOptions(
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }));
            return host;
        }

        public async Task<Host> ValidateHostAsync(Host host)
        {
            var returnedHost = await GetHostByEmail(host.Email);
            if (returnedHost != null && returnedHost.Password == host.Password)
            {
                return host;
            }
            else return null;
        }
    }
}