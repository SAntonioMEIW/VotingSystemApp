using Microsoft.AspNetCore.Server.Kestrel.Core;
//using VotingSystem.Voting;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddGrpc();

//var app = builder.Build();

// Force HTTP/2 for gRPC on port 9091 (plaintext h2c behind Traefik)
/*builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(9091, listen =>
    {
        listen.Protocols = HttpProtocols.Http2;
    });

    // Optional: keep your "/" HTTP endpoint on 9090 (HTTP/1.1)
    options.ListenAnyIP(9090, listen =>
    {
        listen.Protocols = HttpProtocols.Http1;
    });
});*/

builder.Services.AddGrpc();


var app = builder.Build();

app.MapGrpcService<VotingServiceImpl>();

app.MapGet("/", () => "Servidor gRPC - Serviço de Votação ativo.");

app.Run();


