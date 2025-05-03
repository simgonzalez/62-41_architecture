using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SmartFridge.Models;

namespace SmartFridge.Services
{
    internal static class BackendService
    {
        private static readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
        };

        // Static constructor to initialize the HttpClient
        static BackendService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8000/api/")
            };

            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        public static async Task<List<Unit>> GetUnitsAsync()
        {
            return await GetDataAsync<List<Unit>>("units");
        }

        public static async Task<Unit> UpdateUnitAsync(int id, Unit unit)
        {
            return await UpdateDataAsync<Unit, Unit>($"units/{id}", unit);
        }

        public static async Task<Unit> CreateUnitAsync(Unit unit)
        {
            return await CreateDataAsync<Unit, Unit>("units", unit);
        }
        public static async Task DeleteUnitAsync(int id)
        {
            await DeleteDataAsync($"units/{id}");
        }
        public static async Task<List<string>> GetRolesName()
        {
            return await GetDataAsync<List<string>>("roles");
        }

        public static async Task<List<User>> GetUsersAsync()
        {
            return await GetDataAsync<List<User>>("users");
        }

        public static async Task<User> UpdateUserAsync(int id, User user)
        {
            return await UpdateDataAsync<User, User>($"users/{id}", user);
        }
        public static async Task<User> CreateUserAsync(User user)
        {
            return await CreateDataAsync<User, User>("users", user);
        }
        public static async Task DeleteUserAsync(int id)
        {
            await DeleteDataAsync($"users/{id}");
        }
        public static async Task<List<Organization>> GetOrganizationsAsync()
        {
            return await GetDataAsync<List<Organization>>("organizations");
        }

        public static async Task<Organization> CreateOrganizationAsync(Organization organization)
        {
            return await CreateDataAsync<Organization, Organization>("organizations", organization);
        }

        public static async Task<Organization> UpdateOrganizationAsync(int id, Organization organization)
        {
            return await UpdateDataAsync<Organization, Organization>($"organizations/{id}", organization);
        }

        public static async Task<User> GetUserInfoAsync()
        {
            var response = await _httpClient.GetAsync( _httpClient.BaseAddress + "me");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }


        public static async Task LoginAsync(string email, string password)
        {
            var loginData = new
            {
                email = email,
                password = password
            };

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(loginData),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(_httpClient.BaseAddress + "login", jsonContent);

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();

                var errorDetails = JsonSerializer.Deserialize<ErrorResponse>(errorResponse, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                throw new HttpRequestException(errorDetails?.Message ?? "An unknown error occurred during login.");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (loginResponse != null && !string.IsNullOrEmpty(loginResponse.AccessToken))
            {
                SetAuthenticationToken(loginResponse.AccessToken);
            }
        }


        private static void SetAuthenticationToken(string token)
        {
            RemoveAuthenticationToken();            
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        public static void RemoveAuthenticationToken()
        {
            if (_httpClient.DefaultRequestHeaders.Contains("Authorization"))
            {
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
            }
        }

        public static async Task<T> GetDataAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public static async Task<TResponse> CreateDataAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {       
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(data, jsonOptions),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(endpoint, jsonContent);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }


        public static async Task<TResponse> UpdateDataAsync<TRequest, TResponse>(string endpoint, TRequest data)
        {
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(data, jsonOptions),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PutAsync(endpoint, jsonContent);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TResponse>(jsonResponse, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public static async Task DeleteDataAsync(string endpoint)
        {
            var response = await _httpClient.DeleteAsync(endpoint);
            response.EnsureSuccessStatusCode();
        }
    }
}
