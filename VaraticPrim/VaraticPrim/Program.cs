using VaraticPrim.Api;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);


var app = builder.Build();

startup.Configure(app, app.Environment);

app.MapControllers();

app.Run();