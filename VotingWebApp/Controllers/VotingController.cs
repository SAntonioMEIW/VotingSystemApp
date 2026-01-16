using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using VotingSystem;
using VotingSystem.Voting;

[ApiController]
[Route("api/[controller]")]
public class VotingController : ControllerBase
{
    private readonly VoterRegistrationService.VoterRegistrationServiceClient _voterClient;
    private readonly VotingService.VotingServiceClient _votingClient;

     public VotingController(
        VoterRegistrationService.VoterRegistrationServiceClient voterClient,
        VotingService.VotingServiceClient votingClient)
    {
        _voterClient = voterClient;
        _votingClient = votingClient;
    }

    [HttpPost("credentials")]
    public async Task<IActionResult> IssueCredential([FromBody] VoterRequest request)
    {
        var response = await _voterClient.IssueVotingCredentialAsync(request);
        return Ok(response);
    }

    [HttpGet("candidates")]
    public async Task<IActionResult> GetCandidates()
    {
        var response = await _votingClient.GetCandidatesAsync(new GetCandidatesRequest());
        return Ok(response.Candidates);
    }

    [HttpPost("vote")]
    public async Task<IActionResult> Vote([FromBody] VoteRequest request)
    {
        var response = await _votingClient.VoteAsync(request);
        return Ok(response);
    }

    [HttpGet("results")]
    public async Task<IActionResult> GetResults()
    {
        var response = await _votingClient.GetResultsAsync(new GetResultsRequest());
        return Ok(response.Results);
    }
}
