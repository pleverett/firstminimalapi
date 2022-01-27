using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.UseContactsApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
  c.SwaggerDoc("v1",
  new() {Title="Paul's Contacts API", Version="v1"});
});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapContactsApi();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint(
  "/swagger/v1/swagger.json",
  "v1"
));

app.Run();

