using Grpc.Net.Client;
using Grpc.Net.ClientFactory;
using VotingSystem;
using VotingSystem.Voting;

var builder = WebApplication.CreateBuilder(args);

// Configuração dos serviços gRPC
builder.Services.AddGrpcClient<VoterRegistrationService.VoterRegistrationServiceClient>(o =>
{
    o.Address = new Uri("https://localhost:5001");
});

builder.Services.AddGrpcClient<VotingService.VotingServiceClient>(o =>
{
    o.Address = new Uri("https://localhost:5001");
});
/*builder.Services.AddSingleton(services =>
{
    var channel = GrpcChannel.ForAddress("https://localhost:5001");
    return new VoterRegistrationService.VoterRegistrationServiceClient(channel);
});

builder.Services.AddSingleton(services =>
{
    var channel = GrpcChannel.ForAddress("https://localhost:5001");
    return new VotingService.VotingServiceClient(channel);
});*/

// Swagger
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

var app = builder.Build();

// Ativar Swagger em DEV
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();
app.Run();
