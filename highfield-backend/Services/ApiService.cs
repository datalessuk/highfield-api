using highfield_backend.Models;
using System.Linq;
using System.Text.Json;


namespace highfield_backend.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProcessedUserData> GetData()
        {
            var url = "https://recruitment.highfieldqualifications.com/api/test";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<UserData[]>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (data == null || data.Length == 0)
                return new ProcessedUserData();


            var colorFrequency = GetColorFrequency(data);
            
            var modifiedAges = GetAllUsersAge(data)
            
            .ToList();

            return new ProcessedUserData
            {
                ColourFrequency = colorFrequency,
                UsersAges = modifiedAges
            };

        }
        public static List<ColourFrequency> GetColorFrequency(IEnumerable<UserData> data)
        {
            return data.GroupBy(u => u.FavouriteColour)
             .Select(g => new ColourFrequency { Colour = g.Key, Count = g.Count() })
             .OrderByDescending(x => x.Count)
             .ThenBy(x => x.Colour)
             .ToList();
        }

        public static List<UsersAge> GetAllUsersAge(IEnumerable<UserData> data) {
            var today = DateTime.Today;
            return data.Select(u => {
                var age = today.Year - u.Dob.Year;
                if (u.Dob.Date > today.AddYears(-age)) age--;
                return new UsersAge
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    CurrentAge = age,
                    AgeIn20Years = age + 20
                };
            })
            .ToList();
        }
    }
}
