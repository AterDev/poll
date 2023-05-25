namespace Core.Entities.PollEntities;

/// <summary>
/// 议题投票实体类型
/// </summary>
public class PollIssue : EntityBase
{
    /// <summary>
    /// 议题编号
    /// </summary>
    [MaxLength(40)]
    public string IssueNo { get; set; } = default!;

    /// <summary>
    /// 议题标题
    /// </summary>
    [MaxLength(50)]
    public required string Title { get; set; }

    /// <summary>
    /// 议题描述
    /// </summary>
    [MaxLength(2000)]
    public required string Description { get; set; }

    /// <summary>
    /// 议题分类
    /// </summary>
    public PollType PollType { get; set; } = PollType.Issue;

    /// <summary>
    /// 有效开始时间
    /// </summary>
    public DateTimeOffset EffectiveStartDate { get; set; }

    /// <summary>
    /// 有效结束时间
    /// </summary>
    public DateTimeOffset EffectiveEndDate { get; set; }

    /// <summary>
    /// 议题选项列表
    /// </summary>
    public List<PollOption> Options { get; set; } = new();
    public List<PollTag>? Tags { get; set; }

    public PollCategory? Category { get; set; }
}
public enum PollType
{
    /// <summary>
    /// 选举
    /// </summary>
    [Description("选举")]
    Poll,
    /// <summary>
    /// 议事
    /// </summary>
    [Description("议事")]
    Issue
}