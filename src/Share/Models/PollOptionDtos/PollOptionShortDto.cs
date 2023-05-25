using Core.Entities.PollEntities;
namespace Share.Models.PollOptionDtos;
/// <summary>
/// 议题投票选项实体类型概要
/// </summary>
/// <inheritdoc cref="Core.Entities.PollEntities.PollOption"/>
public class PollOptionShortDto
{
    /// <summary>
    /// 投票数
    /// </summary>
    public int VoteCount { get; set; } = 0;
    /// <summary>
    /// 对应议题的导航属性
    /// </summary>
    public PollIssue Issue { get; set; } = default!;
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.UtcNow;
    
}
