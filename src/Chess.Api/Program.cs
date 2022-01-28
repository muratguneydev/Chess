using System.Text.Json.Serialization;
using Chess.Api.Controllers;
using Chess.Api.DTO;

// class Program
// {

// }

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
	.AddControllers()
	.AddJsonOptions(x =>
{
    // serialize enums as strings in api responses
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	//x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
	//x.JsonSerializerOptions.Converters.Add(new BoardJsonConverter());
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new () { Title = "Chess.Api", Version = "v1" });
});

//session
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    //options.Cookie.HttpOnly = true;
    //options.Cookie.IsEssential = true;
});
//
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<ContextSession, ContextSession>();
builder.Services.AddSingleton<ChessSessionRepository, ChessSessionRepository>();
builder.Services.AddSingleton<PieceDTOFactory, PieceDTOFactory>();
builder.Services.AddSingleton<SessionIdDTOFactory, SessionIdDTOFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chess.Api v1"));
}

app.UseHttpsRedirection();

app.UseSession();

app.UseAuthorization();

app.MapControllers();

app.Run();
