namespace Core.Entities.PollEntities;
public class PollCategory : EntityBase
{
    [MaxLength(40)]
    public required string Name { get; set; }
    public List<PollIssue>? Issues { get; set; }
}
