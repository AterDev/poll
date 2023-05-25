namespace Application.CommandStore;
public class PollCategoryCommandStore : CommandSet<PollCategory>
{
    public PollCategoryCommandStore(CommandDbContext context, ILogger<PollCategoryCommandStore> logger) : base(context, logger)
    {
    }

}
