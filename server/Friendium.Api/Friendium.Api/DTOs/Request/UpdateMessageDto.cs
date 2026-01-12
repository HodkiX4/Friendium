using System.ComponentModel.DataAnnotations;

namespace Friendium.Api.DTOs.Request;

public record UpdateMessageDto(
    [Required][MaxLength(500)] string Text
);