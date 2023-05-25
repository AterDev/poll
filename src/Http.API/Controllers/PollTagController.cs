using Core.Const;
using Share.Models.PollTagDtos;
namespace Http.API.Controllers;

/// <summary>
/// 议题分类
/// </summary>
/// <see cref="Application.Manager.PollTagManager"/>
public class PollTagController : ClientControllerBase<IPollTagManager>
{
    private readonly IPollIssueManager _pollIssueManager;

    public PollTagController(
        IUserContext user,
        ILogger<PollTagController> logger,
        IPollTagManager manager,
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
    public async Task<ActionResult<PageList<PollTagItemDto>>> FilterAsync(PollTagFilterDto filter)
    {
        return await manager.FilterAsync(filter);
    }

    /// <summary>
    /// 新增
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<PollTag>> AddAsync(PollTagAddDto dto)
    {
        if (!await _pollIssueManager.ExistAsync(dto.PollIssueId))
            return NotFound("不存在的PollIssue");
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
    public async Task<ActionResult<PollTag?>> UpdateAsync([FromRoute] Guid id, PollTagUpdateDto dto)
    {
        var current = await manager.GetOwnedAsync(id);
        if (current == null) return NotFound(ErrorMsg.NotFoundResource);
        if (current.PollIssue.Id != dto.PollIssueId)
        {
            var pollIssue = await _pollIssueManager.GetCurrentAsync(dto.PollIssueId);
            if (pollIssue == null) return NotFound("不存在的PollIssue");
            current.PollIssue = pollIssue;
        }
        return await manager.UpdateAsync(current, dto);
    }

    /// <summary>
    /// 详情
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<PollTag?>> GetDetailAsync([FromRoute] Guid id)
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
    public async Task<ActionResult<PollTag?>> DeleteAsync([FromRoute] Guid id)
    {
        // 注意删除权限
        var entity = await manager.GetOwnedAsync(id);
        if (entity == null) return NotFound();
        // return Forbid();
        return await manager.DeleteAsync(entity);
    }
}