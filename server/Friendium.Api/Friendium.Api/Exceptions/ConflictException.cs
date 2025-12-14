namespace Friendium.Api.Exceptions;

public sealed class ConflictException : Exception
{
    public ConflictException(string? message = null) : base(message ?? "Conflict") { }
}
