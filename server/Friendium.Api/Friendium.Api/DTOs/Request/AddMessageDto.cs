using System.ComponentModel.DataAnnotations;

namespace Friendium.Api.DTOs.Request;

public record AddMessageDto(
    [Required][MaxLength(500)] string Text
);