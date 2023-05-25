using Core.Entities.PollEntities;
namespace Share.Models.PollOptionDtos;
/// <summary>
/// 议题投票选项实体类型查询筛选
/// </summary>
/// <inheritdoc cref="Core.Entities.PollEntities.PollOption"/>
public class PollOptionFilterDto : FilterBase
{
    /// <summary>
    /// 选项描述
    /// </summary>
    [MaxLength(200)]
    public string? Content { get; set; }
    /// <summary>
    /// 投票数
    /// </summary>
    public int? VoteCount { get; set; }
    public Guid? IssueId { get; set; }
    
}
