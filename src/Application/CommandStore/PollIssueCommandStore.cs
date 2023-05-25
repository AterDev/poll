namespace Application.CommandStore;
public class PollIssueCommandStore : CommandSet<PollIssue>
{
    public PollIssueCommandStore(CommandDbContext context, ILogger<PollIssueCommandStore> logger) : base(context, logger)
    {
    }

}
