using Share.Models.PollTagDtos;

namespace Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IPollTagManager : IDomainManager<PollTag>
{
	/// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<PollTag?> GetOwnedAsync(Guid id);

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<PollTag> CreateNewEntityAsync(PollTagAddDto dto);

    /// <summary>
    /// 获取当前对象,通常是在修改前进行查询
    /// </summary>
    /// <param name="id"></param>
    /// <param name="navigations"></param>
    /// <returns></returns>
    Task<PollTag?> GetCurrentAsync(Guid id, params string[] navigations);
    Task<PollTag> AddAsync(PollTag entity);
    Task<PollTag> UpdateAsync(PollTag entity, PollTagUpdateDto dto);
    Task<PollTag?> FindAsync(Guid id);
    /// <summary>
    /// 查询对象
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <param name="whereExp"></param>
    /// <returns></returns>
    Task<TDto?> FindAsync<TDto>(Expression<Func<PollTag, bool>>? whereExp) where TDto : class;
    /// <summary>
    /// 列表条件查询
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <param name="whereExp"></param>
    /// <returns></returns>
    Task<List<TDto>> ListAsync<TDto>(Expression<Func<PollTag, bool>>? whereExp) where TDto : class;
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    Task<PageList<PollTagItemDto>> FilterAsync(PollTagFilterDto filter);
    Task<PollTag?> DeleteAsync(PollTag entity, bool softDelete = true);
    Task<bool> ExistAsync(Guid id);
}
