using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using AimHigh.BL.Models;

namespace AimHigh.UI.Services.API
{
    public class ApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(configuration["ApiSettings:BaseUrl"]);
        }


        // Update Base URL dynamically with validation
        public void UpdateBaseAddress(string baseUrl)
        {
            if (!Uri.TryCreate(baseUrl, UriKind.Absolute, out var newUri))
            {
                throw new ArgumentException("Invalid base URL provided.");
            }
            _httpClient.BaseAddress = newUri;
        }


        //Generic Get all 
        public async Task<List<T>> GetAllAsync<T>(string apiObject)
        {
            var response = await _httpClient.GetAsync($"api/{apiObject}");
            response.EnsureSuccessStatusCode();

            return await DeserializeResponse<List<T>>(response);
        }

        // Generic GET by ID 
        public async Task<T> GetByIdAsync<T>(Guid id, string apiObject)
        {
            var response = await _httpClient.GetAsync($"api/{apiObject}/{id}");
            response.EnsureSuccessStatusCode();

            return await DeserializeResponse<T>(response);
        }

        // Generic POST
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string apiObject, TRequest requestData)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/{apiObject}", requestData);
            response.EnsureSuccessStatusCode();

            return await DeserializeResponse<TResponse>(response);
        }

        // Generic PUT/Update
        public async Task<T> UpdateAsync<T>(Guid id, string apiObject, T updateObject)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/{apiObject}/{id}", updateObject);
            response.EnsureSuccessStatusCode();

            return await DeserializeResponse<T>(response);
        }

        // Generic DELETE method
        public async System.Threading.Tasks.Task DeleteAsync(string apiObject, Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/{apiObject}/{id}");
            response.EnsureSuccessStatusCode();
            return;
        }

        // Helper for consistent deserialization
        private static async Task<T> DeserializeResponse<T>(HttpResponseMessage response)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

    }
}
