using Core.Entities.PollEntities;
namespace Share.Models.PollIssueDtos;
/// <summary>
/// 议题投票实体类型
/// </summary>
/// <inheritdoc cref="Core.Entities.PollEntities.PollIssue"/>
public class PollIssueFilterDto : FilterBase
{
    /// <summary>
    /// 议题编号
    /// </summary>
    [MaxLength(40)]
    public string? IssueNo { get; set; }
    /// <summary>
    /// 议题标题
    /// </summary>
    [MaxLength(50)]
    public string? Title { get; set; }
    /// <summary>
    /// 议题分类
    /// </summary>
    public PollType? PollType { get; set; }
    /// <summary>
    /// 有效开始时间
    /// </summary>
    public DateTimeOffset? EffectiveStartDate { get; set; }
    /// <summary>
    /// 有效结束时间
    /// </summary>
    public DateTimeOffset? EffectiveEndDate { get; set; }
    public Guid? CategoryId { get; set; }
    
}
