using Share.Models.PollCategoryDtos;

namespace Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IPollCategoryManager : IDomainManager<PollCategory>
{
	/// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<PollCategory?> GetOwnedAsync(Guid id);

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<PollCategory> CreateNewEntityAsync(PollCategoryAddDto dto);

    /// <summary>
    /// 获取当前对象,通常是在修改前进行查询
    /// </summary>
    /// <param name="id"></param>
    /// <param name="navigations"></param>
    /// <returns></returns>
    Task<PollCategory?> GetCurrentAsync(Guid id, params string[] navigations);
    Task<PollCategory> AddAsync(PollCategory entity);
    Task<PollCategory> UpdateAsync(PollCategory entity, PollCategoryUpdateDto dto);
    Task<PollCategory?> FindAsync(Guid id);
    /// <summary>
    /// 查询对象
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <param name="whereExp"></param>
    /// <returns></returns>
    Task<TDto?> FindAsync<TDto>(Expression<Func<PollCategory, bool>>? whereExp) where TDto : class;
    /// <summary>
    /// 列表条件查询
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <param name="whereExp"></param>
    /// <returns></returns>
    Task<List<TDto>> ListAsync<TDto>(Expression<Func<PollCategory, bool>>? whereExp) where TDto : class;
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    Task<PageList<PollCategoryItemDto>> FilterAsync(PollCategoryFilterDto filter);
    Task<PollCategory?> DeleteAsync(PollCategory entity, bool softDelete = true);
    Task<bool> ExistAsync(Guid id);
}