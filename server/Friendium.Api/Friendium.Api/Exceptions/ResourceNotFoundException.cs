namespace Friendium.Api.Exceptions;

public sealed class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException(string? message = null) : base(message ?? "Resource not found") { }
}
