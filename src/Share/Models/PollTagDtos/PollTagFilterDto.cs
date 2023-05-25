using Core.Entities.PollEntities;
namespace Share.Models.PollTagDtos;
/// <summary>
/// 议题分类查询筛选
/// </summary>
/// <inheritdoc cref="Core.Entities.PollEntities.PollTag"/>
public class PollTagFilterDto : FilterBase
{
    [MaxLength(40)]
    public string? Name { get; set; }
    public Guid? PollIssueId { get; set; }
    
}
