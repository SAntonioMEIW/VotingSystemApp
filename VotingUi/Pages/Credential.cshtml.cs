using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;

namespace VotingUi.Pages
{
    public class CredentialModel : PageModel
    {
        [BindProperty]
        public string CitizenCardNumber { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            using var client = new HttpClient();
            var response = await client.PostAsJsonAsync("/api/credentials", new { citizenCardNumber = CitizenCardNumber });
            var result = await response.Content.ReadFromJsonAsync<dynamic>();
            ViewData["Message"] = $"Credencial emitida: {result.credentialId}";
            return Page();
        }
    }
}