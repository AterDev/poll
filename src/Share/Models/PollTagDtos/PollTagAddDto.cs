using Core.Entities.PollEntities;
namespace Share.Models.PollTagDtos;
/// <summary>
/// 议题分类添加时请求结构
/// </summary>
/// <inheritdoc cref="Core.Entities.PollEntities.PollTag"/>
public class PollTagAddDto
{
    [MaxLength(40)]
    public required string Name { get; set; }
    public required Guid PollIssueId { get; set; }
    
}
