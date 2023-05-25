using Core.Entities.PollEntities;
namespace Share.Models.PollTagDtos;
/// <summary>
/// 议题分类列表元素
/// </summary>
/// <inheritdoc cref="Core.Entities.PollEntities.PollTag"/>
public class PollTagItemDto
{
    [MaxLength(40)]
    public string Name { get; set; } = default!;
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTimeOffset CreatedTime { get; set; } = DateTimeOffset.UtcNow;
    public DateTimeOffset UpdatedTime { get; set; } = DateTimeOffset.UtcNow;
    
}
