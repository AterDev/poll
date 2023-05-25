using Core.Entities.PollEntities;
namespace Share.Models.PollOptionDtos;
/// <summary>
/// 议题投票选项实体类型更新时请求结构
/// </summary>
/// <inheritdoc cref="Core.Entities.PollEntities.PollOption"/>
public class PollOptionUpdateDto
{
    /// <summary>
    /// 选项描述
    /// </summary>
    [MaxLength(200)]
    public string Content { get; set; } = default!;
    /// <summary>
    /// 投票数
    /// </summary>
    public int? VoteCount { get; set; }
    public Guid PollIssueId { get; set; } = default!;
    
}
