using CriptografiaApp.Servicos;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("http://*:5191");
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<CryptoService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
