using highfield_backend.Models;
using highfield_backend.Tests.TestData;

namespace highfield_backend.Tests
{
    public class UnitTest2
    {
        [Fact]
        public async Task GetUsers()
        {
            var people = PeopleTestData.GetSamplePeople();
            var result = GetAllUsersAge(people);

            Assert.NotNull(result);
            Assert.NotNull(result);

            Assert.Contains(result, r => r.CurrentAge == 100);

        }

        public static List<UsersAge> GetAllUsersAge(IEnumerable<Person> data)
        {
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