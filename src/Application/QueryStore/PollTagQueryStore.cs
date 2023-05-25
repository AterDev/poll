namespace Application.QueryStore;
public class PollTagQueryStore : QuerySet<PollTag>
{
    public PollTagQueryStore(QueryDbContext context, ILogger<PollTagQueryStore> logger) : base(context, logger)
    {
    }
}


