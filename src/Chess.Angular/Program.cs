using Chess.Angular.Controllers;
using Polly;
using Polly.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new () { Title = "Chess.Angular", Version = "v1" });
});

// Add services to the container.
//builder.Services.AddTransient<HttpClient, HttpClient>();
//https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
//builder.Services.AddHttpClient<IChessApiRequester, ChessApiRequester>();
builder.Services.AddHttpClient<IChessApiRequester, ChessApiRequester>(client =>
{
    //client.BaseAddress = new Uri(Configuration["BaseUrl"]);
})
    .AddPolicyHandler(GetRetryPolicy());
    //.AddPolicyHandler(GetCircuitBreakerPolicy());


builder.Services.AddTransient<ChessApiConfigurationOptions, ChessApiConfigurationOptions>();
builder.Services.AddTransient<ChessApiConfiguration, ChessApiConfiguration>();
//builder.Services.AddTransient<IChessApiRequester, ChessApiRequester>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Chess.Angular v1"));
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");;

app.Run();

static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(2, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
}