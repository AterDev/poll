using Application.Implement;
using Application.IManager;
using Share.Models.SystemOrganizationDtos;

namespace Application.Manager;

public class SystemOrganizationManager : DomainManagerBase<SystemOrganization, SystemOrganizationUpdateDto, SystemOrganizationFilterDto, SystemOrganizationItemDto>, ISystemOrganizationManager
{

    public SystemOrganizationManager(
        DataStoreContext storeContext, 
        ILogger<SystemOrganizationManager> logger,
        IUserContext userContext) : base(storeContext, logger)
    {

        _userContext = userContext;
    }

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public Task<SystemOrganization> CreateNewEntityAsync(SystemOrganizationAddDto dto)
    {
        var entity = dto.MapTo<SystemOrganizationAddDto, SystemOrganization>();
        // other required props
        return Task.FromResult(entity);
    }

    public override async Task<SystemOrganization> UpdateAsync(SystemOrganization entity, SystemOrganizationUpdateDto dto)
    {
    return await base.UpdateAsync(entity, dto);
    }

    public override async Task<PageList<SystemOrganizationItemDto>> FilterAsync(SystemOrganizationFilterDto filter)
    {
        Queryable = Queryable
            .WhereNotNull(filter.Name, q => q.Name == filter.Name);
        // TODO: custom filter conditions
        return await Query.FilterAsync<SystemOrganizationItemDto>(Queryable, filter.PageIndex, filter.PageSize, filter.OrderBy);
    }

    /// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<SystemOrganization?> GetOwnedAsync(Guid id)
    {
        var query = Command.Db.Where(q => q.Id == id);
        // 获取用户所属的对象
        // query = query.Where(q => q.User.Id == _userContext.UserId);
        return await query.FirstOrDefaultAsync();
    }

}
