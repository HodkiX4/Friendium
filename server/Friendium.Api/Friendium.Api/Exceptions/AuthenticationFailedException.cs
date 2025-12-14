namespace Friendium.Api.Exceptions;

public sealed class AuthenticationFailedException : Exception
{
    public AuthenticationFailedException(string? message = null) : base(message ?? "Authentication failed") { }
}
