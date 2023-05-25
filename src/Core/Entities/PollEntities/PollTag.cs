namespace Core.Entities.PollEntities;
/// <summary>
/// 议题分类
/// </summary>
public class PollTag : EntityBase
{
    [MaxLength(40)]
    public required string Name { get; set; }

    public required PollIssue PollIssue { get; set; }
}
