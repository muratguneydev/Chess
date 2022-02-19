using System.Text.Json.Serialization;
using Chess.Api;
using Chess.Api.Controllers;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.Seq("http://localhost:5341"));


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
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();

// builder.Services.AddSession(options =>
// {
//     options.IdleTimeout = TimeSpan.FromSeconds(300);
//     //options.Cookie.HttpOnly = true;
// 	options.Cookie.Name = ".Chess.Session";
//     options.Cookie.IsEssential = true;
// });
//
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//builder.Services.AddScoped<ContextSession, ContextSession>();
builder.Services.AddScoped<ChessSessionRepository, ChessSessionRepository>();
//DTO factories
builder.Services.AddSingleton<SessionDTOFactory, SessionDTOFactory>();
builder.Services.AddSingleton<PieceDTOFactory, PieceDTOFactory>();
builder.Services.AddSingleton<SessionIdDTOFactory, SessionIdDTOFactory>();
builder.Services.AddSingleton<BoardDTOFactory, BoardDTOFactory>();
builder.Services.AddSingleton<MoveDTOFactory, MoveDTOFactory>();
builder.Services.AddSingleton<PlayerDTOFactory, PlayerDTOFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chess.Api v1"));
}

app.UseHttpsRedirection();

//app.UseSession();

app.UseAuthorization();

app.MapControllers();

app.Run();
