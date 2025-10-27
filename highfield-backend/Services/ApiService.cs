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


            var colorFrequency = data
             .GroupBy(u => u.favouriteColour)
             .Select(g => new ColourFrequency { Colour = g.Key, Count = g.Count() })
             .OrderByDescending(x => x.Count)
             .ThenBy(x => x.Colour)
             .ToList();


            var today = DateTime.Today;
            var modifiedAges = data
            .Select(u => {
                var age = today.Year - u.dob.Year;
                if (u.dob.Date > today.AddYears(-age)) age--;
                return new IUsersAge
                {
                    firstName = u.firstName,
                    lastName = u.lastName,
                    currentAge = age,
                    ageIn20Years = age + 20
                };
            })
            .ToList();

            return new ProcessedUserData
            {
                ColourFrequency = colorFrequency,
                UsersAges = modifiedAges
            };

        }

    }
}
