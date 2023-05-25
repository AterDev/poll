using Core.Entities.PollEntities;
namespace Share.Models.PollOptionDtos;
/// <summary>
/// 议题投票选项实体类型列表元素
/// </summary>
/// <inheritdoc cref="Core.Entities.PollEntities.PollOption"/>
public class PollOptionItemDto
{
    /// <summary>
    /// 选项描述
    /// </summary>
    [MaxLength(200)]
    public string Content { get; set; } = default!;
    /// <summary>
    /// 投票数
    /// </summary>
    public int VoteCount { get; set; } = 0;
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.UtcNow;
    
}
