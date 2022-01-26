using System.Text.Json;

namespace Chess.Api.Controllers;

public class ContextSession
{
	private readonly ISession contextSession;

	public ContextSession(IHttpContextAccessor contextAccessor)
	{
		Require.NotNull(contextAccessor, nameof(contextAccessor));
		//Require.NotNull(contextAccessor.HttpContext, nameof(contextAccessor.HttpContext));
		if (contextAccessor.HttpContext == null)
			throw new ArgumentException($"{nameof(contextAccessor.HttpContext)} cannot be null.");
		if (contextAccessor.HttpContext.Session == null)
			throw new ArgumentException($"{nameof(contextAccessor.HttpContext.Session)} cannot be null.");

		this.contextSession = contextAccessor.HttpContext.Session;
	}

	public virtual async Task SetAsync<T>(string key, T value)
    {
		// JsonSerializerOptions options = new()
        //     {
        //         //ReferenceHandler = ReferenceHandler.Preserve,
        //         //WriteIndented = true,
		// 		//PropertyNamingPolicy = null
		// 		Converters = { new BoardJsonConverter() }
        //     };
			
        this.contextSession.SetString(key, JsonSerializer.Serialize(value));
		await this.contextSession.CommitAsync();
    }

    public virtual async Task<T> GetAsync<T>(string key, T defaultValue)
    {
		await this.contextSession.LoadAsync();
        var value = this.contextSession.GetString(key);
        if (value == null)
		{
			if (defaultValue == null)
				throw new ArgumentException("Default value provided was null.");
			return defaultValue;
		}

		var deserializedValue = JsonSerializer.Deserialize<T>(value);
		if (deserializedValue == null)
			throw new ArgumentException("Deserialized value was null.");
		
		return deserializedValue;
    }
}
