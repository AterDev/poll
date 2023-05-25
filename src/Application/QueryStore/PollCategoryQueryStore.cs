namespace Application.QueryStore;
public class PollCategoryQueryStore : QuerySet<PollCategory>
{
    public PollCategoryQueryStore(QueryDbContext context, ILogger<PollCategoryQueryStore> logger) : base(context, logger)
    {
    }
}


