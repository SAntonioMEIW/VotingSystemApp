using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VotingUi.Pages
{
    public class ResultsModel : PageModel
    {
        public List<Result> Results { get; set; }

        public async Task OnGetAsync()
        {
            using var client = new HttpClient();
            Results = await client.GetFromJsonAsync<List<Result>>("/api/results");
        }

        public class Result
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Votes { get; set; }
        }
    }
}
