namespace Application.QueryStore;
public class PollIssueQueryStore : QuerySet<PollIssue>
{
    public PollIssueQueryStore(QueryDbContext context, ILogger<PollIssueQueryStore> logger) : base(context, logger)
    {
    }
}


