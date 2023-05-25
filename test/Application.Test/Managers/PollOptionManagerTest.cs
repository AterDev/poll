using Application.IManager;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Share.Models.PollOptionDtos;

namespace Application.Test.Managers;

public class PollOptionManagerTest : BaseTest
{
    private readonly IPollOptionManager manager;
    public string RandomString { get; set; }

    public PollOptionManagerTest(WebApplicationFactory<Program> factory) : base(factory)
    {
        manager = Services.GetRequiredService<IPollOptionManager>();
        RandomString = DateTime.Now.ToString("MMddmmss");
    }
    [Fact]
    public async Task PollOption_Should_Pass()
    {
        await Shoud_AddAsync();
        await Should_UpdateAsync();
        await Should_QueryAsync();
    }

    async internal Task Shoud_AddAsync()
    {
        var dto = new PollOptionAddDto()
        {
            Content = "Content" + RandomString,
            VoteCount = 0,
            PollIssueId = Guid.NewGuid(),
        };
        var entity = await manager.CreateNewEntityAsync(dto);
        var res = await manager.AddAsync(entity);
        Assert.Equal(entity.Content, res.Content);
        Assert.Equal(entity.VoteCount, res.VoteCount);

    }

    async internal Task Should_UpdateAsync()
    {
        var dto = new PollOptionUpdateDto()
        {
            Content = "UpdateContent" + RandomString,
            VoteCount = 0,
            PollIssueId = new Guid(""),
        };
        var entity = await manager.Command.Db.FirstOrDefaultAsync();
        if (entity != null)
        {
            var res = await manager.UpdateAsync(entity, dto);
            Assert.Equal(entity.Content, res.Content);
            Assert.Equal(entity.VoteCount, res.VoteCount);

        }
    }

    async internal Task Should_QueryAsync()
    {
        var filter = new PollOptionFilterDto()
        {
            PageIndex = 1,
            PageSize = 2
        };
        var res = await manager.FilterAsync(filter);
        Assert.True(res != null && res.Count != 0 && res.Data.Count <= 2);
    }
}
