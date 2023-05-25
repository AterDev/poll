namespace Application.CommandStore;
public class PollOptionCommandStore : CommandSet<PollOption>
{
    public PollOptionCommandStore(CommandDbContext context, ILogger<PollOptionCommandStore> logger) : base(context, logger)
    {
    }

}
