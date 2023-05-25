using Application.Implement;
using Application.IManager;
using Share.Models.PollOptionDtos;

namespace Application.Manager;

public class PollOptionManager : DomainManagerBase<PollOption, PollOptionUpdateDto, PollOptionFilterDto, PollOptionItemDto>, IPollOptionManager
{

    public PollOptionManager(
        DataStoreContext storeContext, 
        ILogger<PollOptionManager> logger,
        IUserContext userContext) : base(storeContext, logger)
    {

        _userContext = userContext;
    }

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<PollOption> CreateNewEntityAsync(PollOptionAddDto dto)
    {
        var entity = dto.MapTo<PollOptionAddDto, PollOption>();
        Command.Db.Entry(entity).Property("IssueId").CurrentValue = dto.PollIssueId;
        // or entity.IssueId = dto.PollIssueId;
        // other required props
        return await Task.FromResult(entity);
    }

    public override async Task<PollOption> UpdateAsync(PollOption entity, PollOptionUpdateDto dto)
    {
    return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<PollOptionItemDto>> FilterAsync(PollOptionFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.IssueId, q => q.Issue.Id == filter.IssueId);
        // TODO: custom filter conditions
        return await Query.FilterAsync<PollOptionItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<PollOption?> GetOwnedAsync(Guid id)
    {
        var query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
