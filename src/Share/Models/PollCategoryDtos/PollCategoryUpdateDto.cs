using Core.Entities.PollEntities;
namespace Share.Models.PollCategoryDtos;

/// <inheritdoc cref="Core.Entities.PollEntities.PollCategory"/>
public class PollCategoryUpdateDto
{
    [MaxLength(40)]
    public string Name { get; set; } = default!;
    public List<Guid>? PollIssueIds { get; set; }
    
}
