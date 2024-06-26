using api.DbContext;
using api.Extension;
using shorten.link.api.Endpoint;
using Microsoft.EntityFrameworkCore;
using shorten.link.api.Implementation;
using shorten.link.api.Implementation.Abstraction;

var corsPolicyName = "Default";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ILinkService, LinkService>();
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddDbContext<ShortenLinkDbContext>(options => {
    var connectionString = builder.Configuration.GetConnectionString("Default");
    options.UseSqlServer(connectionString);
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
                      policy =>
                      {
                          policy.AllowAnyOrigin();
                      });
});

var app = builder.Build();
app.MapLinkEndpoints();
app.MigrateDbContext();
app.UseCors();
app.Run();