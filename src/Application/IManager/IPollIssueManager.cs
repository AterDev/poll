using Share.Models.PollIssueDtos;

namespace Application.IManager;
/// <summary>
/// 定义实体业务接口规范
/// </summary>
public interface IPollIssueManager : IDomainManager<PollIssue>
{
	/// <summary>
    /// 当前用户所拥有的对象
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<PollIssue?> GetOwnedAsync(Guid id);

    /// <summary>
    /// 创建待添加实体
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<PollIssue> CreateNewEntityAsync(PollIssueAddDto dto);

    /// <summary>
    /// 获取当前对象,通常是在修改前进行查询
    /// </summary>
    /// <param name="id"></param>
    /// <param name="navigations"></param>
    /// <returns></returns>
    Task<PollIssue?> GetCurrentAsync(Guid id, params string[] navigations);
    Task<PollIssue> AddAsync(PollIssue entity);
    Task<PollIssue> UpdateAsync(PollIssue entity, PollIssueUpdateDto dto);
    Task<PollIssue?> FindAsync(Guid id);
    /// <summary>
    /// 查询对象
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <param name="whereExp"></param>
    /// <returns></returns>
    Task<TDto?> FindAsync<TDto>(Expression<Func<PollIssue, bool>>? whereExp) where TDto : class;
    /// <summary>
    /// 列表条件查询
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <param name="whereExp"></param>
    /// <returns></returns>
    Task<List<TDto>> ListAsync<TDto>(Expression<Func<PollIssue, bool>>? whereExp) where TDto : class;
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    Task<PageList<PollIssueItemDto>> FilterAsync(PollIssueFilterDto filter);
    Task<PollIssue?> DeleteAsync(PollIssue entity, bool softDelete = true);
    Task<bool> ExistAsync(Guid id);
}
