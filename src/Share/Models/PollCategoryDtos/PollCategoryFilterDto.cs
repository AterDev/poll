using Core.Entities.PollEntities;
namespace Share.Models.PollCategoryDtos;

/// <inheritdoc cref="Core.Entities.PollEntities.PollCategory"/>
public class PollCategoryFilterDto : FilterBase
{
    [MaxLength(40)]
    public string? Name { get; set; }
    
}
