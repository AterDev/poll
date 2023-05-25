using Core.Const;
using Share.Models.PollCategoryDtos;
namespace Http.API.Controllers.AdminControllers;


/// <see cref="Application.Manager.PollCategoryManager"/>
public class PollCategoryController : RestControllerBase<IPollCategoryManager>
{

    public PollCategoryController(
        IUserContext user,
        ILogger<PollCategoryController> logger,
        IPollCategoryManager manager
        ) : base(manager, user, logger)
    {

    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<PollCategoryItemDto>>> FilterAsync(PollCategoryFilterDto filter)
    {
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<PollCategory>> AddAsync(PollCategoryAddDto dto)
    {
        var entity = await manager.CreateNewEntityAsync(dto);
        return await manager.AddAsync(entity);
    }

    /// <summary>
    /// 更新
    /// </summary>
    /// <param name="id"></param>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<PollCategory?>> UpdateAsync([FromRoute] Guid id, PollCategoryUpdateDto dto)
    {
        var current = await manager.GetOwnedAsync(id);
        if (current == null) return NotFound(ErrorMsg.NotFoundResource);
        return await manager.UpdateAsync(current, dto);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<PollCategory?>> GetDetailAsync([FromRoute] Guid id)
    {
        var res = await manager.FindAsync(id);
        return (res == null) ? NotFound() : res;
    }

    /// <summary>
    /// ⚠删除
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    // [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<PollCategory?>> DeleteAsync([FromRoute] Guid id)
    {
        // 注意删除权限
        var entity = await manager.GetOwnedAsync(id);
        if (entity == null) return NotFound();
        // return Forbid();
        return await manager.DeleteAsync(entity);
    }
}