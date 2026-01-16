using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace VotingUi.Pages
{
    public class CandidatesModel : PageModel
    {
        public List<Candidate>? Candidates { get; set; }

        public async Task OnGetAsync()
        {
            using var client = new HttpClient();
            var response = await client.GetFromJsonAsync<List<Candidate>>("/api/candidates");
            Candidates = response;
        }

        public async Task<IActionResult> OnPostVoteAsync(int candidateId)
        {
            using var client = new HttpClient();
            await client.PostAsJsonAsync("/api/vote", new { candidateId });
            return RedirectToPage();
        }

        public class Candidate
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


    }
}