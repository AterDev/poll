namespace Core.Entities.PollEntities;
/// <summary>
/// 议题投票选项实体类型
/// </summary>
public class PollOption : EntityBase
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

    /// <summary>
    /// 对应议题的导航属性
    /// </summary>
    public required PollIssue Issue { get; set; }
}