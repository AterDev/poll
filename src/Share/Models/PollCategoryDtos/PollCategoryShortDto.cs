using Core.Entities.PollEntities;
namespace Share.Models.PollCategoryDtos;

/// <inheritdoc cref="Core.Entities.PollEntities.PollCategory"/>
public class PollCategoryShortDto
{
    [MaxLength(40)]
    public string Name { get; set; } = default!;
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.UtcNow;
    
}
