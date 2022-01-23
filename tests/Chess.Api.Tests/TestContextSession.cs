using System.Diagnostics.CodeAnalysis;
using System.Security.Claims;
using Chess.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace Chess.Api.Tests;

public class TestContextSession : ContextSession
{
	private readonly object valueToReturnFromSession;

	public TestContextSession(object valueToReturnFromSession)
		: base(new TestHttpContextAccessor())
	{
		this.valueToReturnFromSession = valueToReturnFromSession;
	}

	public override Task<T> GetAsync<T>(string key, T defaultValue)
	{
		return Task.FromResult<T>((T)this.valueToReturnFromSession);
	}
}

public class TestHttpContextAccessor : IHttpContextAccessor
{
	public HttpContext? HttpContext
	{
		get => new TestHttpContext();
		set => throw new NotImplementedException();
	}
}

public class TestHttpContext : HttpContext
{
	public override IFeatureCollection Features => throw new NotImplementedException();

	public override HttpRequest Request => throw new NotImplementedException();

	public override HttpResponse Response => throw new NotImplementedException();

	public override ConnectionInfo Connection => throw new NotImplementedException();

	public override WebSocketManager WebSockets => throw new NotImplementedException();

	public override ClaimsPrincipal User { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public override IDictionary<object, object?> Items { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public override IServiceProvider RequestServices { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public override CancellationToken RequestAborted { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public override string TraceIdentifier { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public override ISession Session
	{
		get => new TestSession();
		set => throw new NotImplementedException();
	}

	public override void Abort()
	{
		throw new NotImplementedException();
	}
}

public class TestSession : ISession
{
	public bool IsAvailable => throw new NotImplementedException();

	public string Id => throw new NotImplementedException();

	public IEnumerable<string> Keys => throw new NotImplementedException();

	public void Clear()
	{
		throw new NotImplementedException();
	}

	public Task CommitAsync(CancellationToken cancellationToken = default)
	{
		return Task.CompletedTask;
	}

	public Task LoadAsync(CancellationToken cancellationToken = default)
	{
		return Task.CompletedTask;
	}

	public void Remove(string key)
	{
		throw new NotImplementedException();
	}

	public void Set(string key, byte[] value)
	{
		
	}

	public bool TryGetValue(string key, [NotNullWhen(true)] out byte[]? value)
	{
		throw new NotImplementedException();
	}
}