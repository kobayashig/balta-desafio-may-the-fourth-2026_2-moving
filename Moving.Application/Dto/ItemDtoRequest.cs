using System.ComponentModel.DataAnnotations;

namespace Moving.Application.Dto;

public record ItemDtoRequest(
    [Required]
    [MaxLength(100)]
    string Name,
    [Required]
    [Range(1, int.MaxValue)]
    int Box);