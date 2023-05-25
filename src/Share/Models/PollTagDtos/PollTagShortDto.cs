using Core.Entities.PollEntities;
namespace Share.Models.PollTagDtos;
/// <summary>
/// 议题分类概要
/// </summary>
/// <inheritdoc cref="Core.Entities.PollEntities.PollTag"/>
public class PollTagShortDto
{
    [MaxLength(40)]
    public string Name { get; set; } = default!;
    public PollIssue PollIssue { get; set; } = default!;
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.UtcNow;
    
}
