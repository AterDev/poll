using Core.Entities.PollEntities;
namespace Share.Models.PollTagDtos;
/// <summary>
/// 议题分类更新时请求结构
/// </summary>
/// <inheritdoc cref="Core.Entities.PollEntities.PollTag"/>
public class PollTagUpdateDto
{
    [MaxLength(40)]
    public string Name { get; set; } = default!;
    public Guid PollIssueId { get; set; } = default!;
    
}
