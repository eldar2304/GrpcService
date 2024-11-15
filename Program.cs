using GrpcService.Models;
using GrpcService.Services;


var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682


ApplicationContext appDb = new ApplicationContext();
//appDb.Clients.Add(new Client { Id = 1, Name = "SEF", Password = "12345", Phone = 4001 });
//appDb.Accounts.Add(new Account { Id = 1, AccountNum = 123, AccoutType = 0,  ClientId = 1 });
//appDb.SaveChanges();

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<UserAccountService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");



app.Run();
