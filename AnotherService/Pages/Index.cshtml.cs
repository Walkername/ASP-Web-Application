using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AnotherService.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly HttpClient _httpClient;

        public List<AppUser> AppUsers { get; set; } = new List<AppUser>();
        public List<byte[]?> ProfilePictures { get; set; } = new List<byte[]?>();

        public IndexModel(ILogger<IndexModel> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7288");
        }

        public async Task OnGetAsync()
        {
            var response = await _httpClient.GetAsync($"/userprofiles/");
            if (response.IsSuccessStatusCode)
            {
                AppUsers = await response.Content.ReadFromJsonAsync<List<AppUser>>() ?? new List<AppUser>();
            }
        }
    }
}