
using System.Text.Json;
using highfield_backend.Tests.TestData;
namespace highfield_backend.Tests
{
    public class ApiServiceTests
    {
        [Fact]
        public async Task GetData_ReturnsProcessedUserData()
        {
            var people = PeopleTestData.GetSamplePeople();
            var result = GetColorFrequency(people);
            
            Assert.NotNull(result);
            Assert.Contains(result, r => r.Colour == "Mauv" && r.Count == 2);
            Assert.Contains(result, r => r.Colour == "Indigo" && r.Count == 2);
            Assert.Contains(result, r => r.Colour == "Goldenrod" && r.Count == 1);


            var expectedOrder = result.OrderByDescending(r => r.Count).ThenBy(r => r.Colour).ToList();
            Assert.Equal(expectedOrder.Select(x => x.Colour), result.Select(x => x.Colour));

            var json = JsonSerializer.Serialize(people);
        }

        public class ColourFrequency
        {
            public string Colour { get; set; }
            public int Count { get; set; }
        }

        public static List<ColourFrequency> GetColorFrequency(IEnumerable<Person> data)
        {
            return data.GroupBy(u => u.FavouriteColour)
                       .Select(g => new ColourFrequency { Colour = g.Key, Count = g.Count() })
                       .OrderByDescending(x => x.Count)
                       .ThenBy(x => x.Colour)
                       .ToList();
        }
    }
}
