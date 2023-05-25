namespace Application.CommandStore;
public class PollTagCommandStore : CommandSet<PollTag>
{
    public PollTagCommandStore(CommandDbContext context, ILogger<PollTagCommandStore> logger) : base(context, logger)
    {
    }

}
