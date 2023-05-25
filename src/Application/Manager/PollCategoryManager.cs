using Application.Implement;
using Application.IManager;
using Share.Models.PollCategoryDtos;

namespace Application.Manager;

public class PollCategoryManager : DomainManagerBase<PollCategory, PollCategoryUpdateDto, PollCategoryFilterDto, PollCategoryItemDto>, IPollCategoryManager
{

    public PollCategoryManager(
        DataStoreContext storeContext, 
        ILogger<PollCategoryManager> logger,
        IUserContext userContext) : base(storeContext, logger)
    {

        _userContext = userContext;
    }

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<PollCategory> CreateNewEntityAsync(PollCategoryAddDto dto)
    {
        var entity = dto.MapTo<PollCategoryAddDto, PollCategory>();
        // other required props
        return await Task.FromResult(entity);
    }

    public override async Task<PollCategory> UpdateAsync(PollCategory entity, PollCategoryUpdateDto dto)
    {
    return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<PollCategoryItemDto>> FilterAsync(PollCategoryFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.Name, q => q.Name == filter.Name);
        // TODO: custom filter conditions
        return await Query.FilterAsync<PollCategoryItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<PollCategory?> GetOwnedAsync(Guid id)
    {
        var query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
