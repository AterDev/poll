namespace Application.QueryStore;
public class PollOptionQueryStore : QuerySet<PollOption>
{
    public PollOptionQueryStore(QueryDbContext context, ILogger<PollOptionQueryStore> logger) : base(context, logger)
    {
    }
}


