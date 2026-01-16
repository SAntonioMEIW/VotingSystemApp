using Microsoft.AspNetCore.Mvc;
using VotingSystem;
using VotingSystem.Voting;

[ApiController]
[Route("api/[controller]")]
public class CredentialsController : ControllerBase
{
    private readonly VoterRegistrationService.VoterRegistrationServiceClient _client;

    public CredentialsController(VoterRegistrationService.VoterRegistrationServiceClient client)
    {
        _client = client;
    }

    [HttpPost]
    public async Task<IActionResult> IssueCredential([FromBody] IssueVotingCredentialRequest request)
    {
        var response = await _client.IssueVotingCredentialAsync(request);
        return Ok(response);
    }
}
