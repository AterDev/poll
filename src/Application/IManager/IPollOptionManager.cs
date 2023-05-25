using Share.Models.PollOptionDtos;

namespace Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IPollOptionManager : IDomainManager<PollOption>
{
	/// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<PollOption?> GetOwnedAsync(Guid id);

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<PollOption> CreateNewEntityAsync(PollOptionAddDto dto);

    /// <summary>
    /// 获取当前对象,通常是在修改前进行查询
    /// </summary>
    /// <param name="id"></param>
    /// <param name="navigations"></param>
    /// <returns></returns>
    Task<PollOption?> GetCurrentAsync(Guid id, params string[] navigations);
    Task<PollOption> AddAsync(PollOption entity);
    Task<PollOption> UpdateAsync(PollOption entity, PollOptionUpdateDto dto);
    Task<PollOption?> FindAsync(Guid id);
    /// <summary>
    /// 查询对象
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <param name="whereExp"></param>
    /// <returns></returns>
    Task<TDto?> FindAsync<TDto>(Expression<Func<PollOption, bool>>? whereExp) where TDto : class;
    /// <summary>
    /// 列表条件查询
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <param name="whereExp"></param>
    /// <returns></returns>
    Task<List<TDto>> ListAsync<TDto>(Expression<Func<PollOption, bool>>? whereExp) where TDto : class;
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    Task<PageList<PollOptionItemDto>> FilterAsync(PollOptionFilterDto filter);
    Task<PollOption?> DeleteAsync(PollOption entity, bool softDelete = true);
    Task<bool> ExistAsync(Guid id);
}
