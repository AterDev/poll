using Core.Entities.PollEntities;
namespace Share.Models.PollCategoryDtos;

/// <inheritdoc cref="Core.Entities.PollEntities.PollCategory"/>
public class PollCategoryAddDto
{
    [MaxLength(40)]
    public required string Name { get; set; }
    public List<Guid>? PollIssueIds { get; set; }
    
}
