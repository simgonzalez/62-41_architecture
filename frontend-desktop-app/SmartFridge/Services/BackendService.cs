using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        public static async Task LogoutAsync()
        {
            await _httpClient.PostAsync("logout", null);
            RemoveAuthenticationToken();
        }

        public static async Task RegisterAsync(string firstName, string name, string email, string password)
        {
            var registrationData = new
            {
                first_name = firstName,
                name = name,
                email = email,
                password = password
            };

            await CreateDataAsync<object, object>("register", registrationData);
        }

        public static async Task<List<Organization>> GetFilteredOrganizationsAsync(string queryString, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"organizations?{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Organization>>(jsonResponse, jsonOptions);
        }

        public static async Task<List<FoodRequest>> GetFilteredFoodRequestsAsync(string queryString, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"food-requests?{queryString}", cancellationToken);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<FoodRequest>>(jsonResponse, jsonOptions);
        }

        public static async Task<List<User>> GetUsersForOrganizationAsync()
        {
            return await GetDataAsync<List<User>>("users-org");
        }

        public static async Task AddUserToOrganizationAsync(int organizationId, int userId)
        {
            var payload = new { user_id = userId };

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync($"organizations/{organizationId}/users", jsonContent);
            response.EnsureSuccessStatusCode();
        }

        public static async Task RemoveUserFromOrganizationAsync(int organizationId, int userId)
        {
            var response = await _httpClient.DeleteAsync($"organizations/{organizationId}/users/{userId}");
            response.EnsureSuccessStatusCode();
        }

        public static async Task<List<User>> GetOrganizationUsersAsync(int organizationId)
        {
            return await GetDataAsync<List<User>>($"organizations/{organizationId}/users");
        }

        public static async Task<Organization> GetCurrentUserOrganizationAsync()
        {
            return await GetDataAsync<Organization>("me/organization");
        }

        public static async Task<List<Food>> getFoodsAsync()
        {
            return await GetDataAsync<List<Food>>("foods");
        }

        public static async Task<List<FoodRequestItem>> GetFoodRequestItemsAsync(int requestId)
        {
            return await GetDataAsync<List<FoodRequestItem>>($"food-requests/{requestId}/items");
        }
        public static async Task<FoodRequestItem> CreateFoodRequestItemAsync(int requestId, FoodRequestItem item)
        {
            return await CreateDataAsync<FoodRequestItem, FoodRequestItem>($"food-requests/{requestId}/items", item);
        }

        public static async Task<List<FoodRequest>> GetFoodRequestsAsync()
        {
            return await GetDataAsync<List<FoodRequest>>("food-requests");
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
            // Serialize the user object, excluding the password if it should not be serialized
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(user, new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PutAsync($"users/{id}", jsonContent);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(jsonResponse, jsonOptions);
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
