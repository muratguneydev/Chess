using System.Text.Json;
using Chess.Api.Request;
using Microsoft.Net.Http.Headers;

namespace Chess.Angular.Controllers;

public class ChessApiRequester : IChessApiRequester
{
	private readonly ChessApiConfiguration chessApiConfiguration;
	private readonly HttpClient httpClient;
	//private readonly IHttpClientFactory httpClientFactory;

	public ChessApiRequester(ChessApiConfiguration chessApiConfiguration, HttpClient httpClient)
	{
		this.chessApiConfiguration = chessApiConfiguration;
		this.httpClient = httpClient;
		//this.httpClientFactory = httpClientFactory;
		//this.httpClient = httpClientFactory.CreateClient();
	}

	public async Task<string> CreateSession()
	{
		var response = await this.httpClient.PostAsync(this.chessApiConfiguration.SessionEndPoint, null);
		response.EnsureSuccessStatusCode();
		var result = await response.Content.ReadAsStringAsync();
		return result;
	}

	public async Task<string> Register(RegisterRequest registerRequest)
	{
		string json = JsonSerializer.Serialize(registerRequest);

        var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
		
		var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Put,
            this.chessApiConfiguration.RegisterEndPoint)
        {
            Headers =
            {
                //{ "Accept", "application/vnd.github.v3+json" },
                //{ "User-Agent", "HttpRequestsConsoleSample" },
				{ "Cookie", new CookieHeaderValue("Set-Cookie", "123").ToString() }
            },
			Content = httpContent
        };

		//var response = await this.httpClient.PutAsync(this.chessApiConfiguration.RegisterEndPoint, httpContent);
		var response = await this.httpClient.SendAsync(httpRequestMessage);
		response.EnsureSuccessStatusCode();
		var result = await response.Content.ReadAsStringAsync();
		return result;
	}

	public async Task<string> Ready(ReadyRequest readyRequest)
	{
		string json = JsonSerializer.Serialize(readyRequest);

        var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

		var response = await this.httpClient.PutAsync(this.chessApiConfiguration.ReadyEndPoint, httpContent);
		response.EnsureSuccessStatusCode();
		var result = await response.Content.ReadAsStringAsync();
		return result;
	}

	public async Task<string> Move(MoveRequest moveRequest)
	{
		string json = JsonSerializer.Serialize(moveRequest);

        var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

		var response = await this.httpClient.PutAsync(this.chessApiConfiguration.MoveEndPoint, httpContent);
		response.EnsureSuccessStatusCode();
		var result = await response.Content.ReadAsStringAsync();
		return result;
	}
}

