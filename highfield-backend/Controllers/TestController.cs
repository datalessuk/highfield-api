using highfield_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace highfield_backend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {

        private readonly HttpClient _httpClient;
        private readonly ApiService _apiService;

        public TestController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTestData()
        {
            var data = await _apiService.GetData();
            return Ok(data);
        }
    }
}
