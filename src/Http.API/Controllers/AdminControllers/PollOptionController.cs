using Core.Const;
using Share.Models.PollOptionDtos;
namespace Http.API.Controllers.AdminControllers;

/// <summary>
/// 议题投票选项实体类型
/// </summary>
/// <see cref="Application.Manager.PollOptionManager"/>
public class PollOptionController : RestControllerBase<IPollOptionManager>
{
    private readonly IPollIssueManager _pollIssueManager;

    public PollOptionController(
        IUserContext user,
        ILogger<PollOptionController> logger,
        IPollOptionManager manager,
        IPollIssueManager pollIssueManager
        ) : base(manager, user, logger)
    {
        _pollIssueManager = pollIssueManager;

    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpPost("filter")]
    public async Task<ActionResult<PageList<PollOptionItemDto>>> FilterAsync(PollOptionFilterDto filter)
    {
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<PollOption>> AddAsync(PollOptionAddDto dto)
    {
        if (!await _pollIssueManager.ExistAsync(dto.PollIssueId))
            return NotFound("不存在的对应议题的导航属性");
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
    public async Task<ActionResult<PollOption?>> UpdateAsync([FromRoute] Guid id, PollOptionUpdateDto dto)
    {
        var current = await manager.GetOwnedAsync(id);
        if (current == null) return NotFound(ErrorMsg.NotFoundResource);
        if (current.Issue.Id != dto.PollIssueId)
        {
            var pollIssue = await _pollIssueManager.GetCurrentAsync(dto.PollIssueId);
            if (pollIssue == null) return NotFound("不存在的对应议题的导航属性");
            current.Issue = pollIssue;
        }
        return await manager.UpdateAsync(current, dto);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<PollOption?>> GetDetailAsync([FromRoute] Guid id)
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
    public async Task<ActionResult<PollOption?>> DeleteAsync([FromRoute] Guid id)
    {
        // 注意删除权限
        var entity = await manager.GetOwnedAsync(id);
        if (entity == null) return NotFound();
        // return Forbid();
        return await manager.DeleteAsync(entity);
    }
}