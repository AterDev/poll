using Application.Implement;
using Application.IManager;
using Share.Models.PollTagDtos;

namespace Application.Manager;

public class PollTagManager : DomainManagerBase<PollTag, PollTagUpdateDto, PollTagFilterDto, PollTagItemDto>, IPollTagManager
{

    public PollTagManager(
        DataStoreContext storeContext, 
        ILogger<PollTagManager> logger,
        IUserContext userContext) : base(storeContext, logger)
    {

        _userContext = userContext;
    }

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<PollTag> CreateNewEntityAsync(PollTagAddDto dto)
    {
        var entity = dto.MapTo<PollTagAddDto, PollTag>();
        Command.Db.Entry(entity).Property("PollIssueId").CurrentValue = dto.PollIssueId;
        // or entity.PollIssueId = dto.PollIssueId;
        // other required props
        return await Task.FromResult(entity);
    }

    public override async Task<PollTag> UpdateAsync(PollTag entity, PollTagUpdateDto dto)
    {
    return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<PollTagItemDto>> FilterAsync(PollTagFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.Name, q => q.Name == filter.Name)
            .WhereNotNull(filter.PollIssueId, q => q.PollIssue.Id == filter.PollIssueId);
        // TODO: custom filter conditions
        return await Query.FilterAsync<PollTagItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<PollTag?> GetOwnedAsync(Guid id)
    {
        var query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
