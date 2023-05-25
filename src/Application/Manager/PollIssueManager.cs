using Application.Implement;
using Application.IManager;
using Share.Models.PollIssueDtos;

namespace Application.Manager;

public class PollIssueManager : DomainManagerBase<PollIssue, PollIssueUpdateDto, PollIssueFilterDto, PollIssueItemDto>, IPollIssueManager
{
    private readonly IPollOptionManager _pollOptionManager;

    public PollIssueManager(
        DataStoreContext storeContext, 
        ILogger<PollIssueManager> logger,
        IUserContext userContext,
        IPollOptionManager pollOptionManager) : base(storeContext, logger)
    {
        _pollOptionManager = pollOptionManager;

        _userContext = userContext;
    }

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<PollIssue> CreateNewEntityAsync(PollIssueAddDto dto)
    {
        var entity = dto.MapTo<PollIssueAddDto, PollIssue>();
        if (dto.PollOptionIds != null && dto.PollOptionIds.Any())
        {
            var options = await _pollOptionManager.Command.Db.Where(t => dto.PollOptionIds.Contains(t.Id)).ToListAsync();
            if (options != null)
            {
                entity.Options = options;
            }
        }        // other required props
        return await Task.FromResult(entity);
    }

    public override async Task<PollIssue> UpdateAsync(PollIssue entity, PollIssueUpdateDto dto)
    {
        if (dto.PollOptionIds != null && dto.PollOptionIds.Any())
        {
            var options = await _pollOptionManager.Command.Db.Where(t => dto.PollOptionIds.Contains(t.Id)).ToListAsync();
            if (options != null)
            {
                entity.Options = options;
            }
        }    return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<PollIssueItemDto>> FilterAsync(PollIssueFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.Title, q => q.Title == filter.Title);
        // TODO: custom filter conditions
        return await Query.FilterAsync<PollIssueItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<PollIssue?> GetOwnedAsync(Guid id)
    {
        var query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
