using Core.Entities.PollEntities;
namespace Share.Models.PollOptionDtos;
/// <summary>
/// 议题投票选项实体类型添加时请求结构
/// </summary>
/// <inheritdoc cref="Core.Entities.PollEntities.PollOption"/>
public class PollOptionAddDto
{
    /// <summary>
    /// 选项描述
    /// </summary>
    [MaxLength(200)]
    public required string Content { get; set; }
    /// <summary>
    /// 投票数
    /// </summary>
    public int VoteCount { get; set; } = 0;
    public required Guid PollIssueId { get; set; }
    
}
