using Share.Models.RolePermissionDtos;

namespace Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IRolePermissionManager : IDomainManager<RolePermission>
{
	/// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<RolePermission?> GetOwnedAsync(Guid id);

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<RolePermission> CreateNewEntityAsync(RolePermissionAddDto dto);

    /// <summary>
    /// 获取当前对象,通常是在修改前进行查询
    /// </summary>
    /// <param name="id"></param>
    /// <param name="navigations"></param>
    /// <returns></returns>
    Task<RolePermission?> GetCurrentAsync(Guid id, params string[] navigations);
    Task<RolePermission> AddAsync(RolePermission entity);
    Task<RolePermission> UpdateAsync(RolePermission entity, RolePermissionUpdateDto dto);
    Task<RolePermission?> FindAsync(Guid id);
    /// <summary>
    /// 查询对象
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <param name="whereExp"></param>
    /// <returns></returns>
    Task<TDto?> FindAsync<TDto>(Expression<Func<RolePermission, bool>>? whereExp) where TDto : class;
    /// <summary>
    /// 列表条件查询
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <param name="whereExp"></param>
    /// <returns></returns>
    Task<List<TDto>> ListAsync<TDto>(Expression<Func<RolePermission, bool>>? whereExp) where TDto : class;
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    Task<PageList<RolePermissionItemDto>> FilterAsync(RolePermissionFilterDto filter);
    Task<RolePermission?> DeleteAsync(RolePermission entity, bool softDelete = true);
    Task<bool> ExistAsync(Guid id);
}
