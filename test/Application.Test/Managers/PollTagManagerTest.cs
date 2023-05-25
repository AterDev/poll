using Application.IManager;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Share.Models.PollTagDtos;

namespace Application.Test.Managers;

public class PollTagManagerTest : BaseTest
{
    private readonly IPollTagManager manager;
    public string RandomString { get; set; }

    public PollTagManagerTest(WebApplicationFactory<Program> factory) : base(factory)
    {
        manager = Services.GetRequiredService<IPollTagManager>();
        RandomString = DateTime.Now.ToString("MMddmmss");
    }
    [Fact]
    public async Task PollTag_Should_Pass()
    {
        await Shoud_AddAsync();
        await Should_UpdateAsync();
        await Should_QueryAsync();
    }

    async internal Task Shoud_AddAsync()
    {
        var dto = new PollTagAddDto()
        {
            Name = "Name" + RandomString,
            PollIssueId = Guid.NewGuid(),
        };
        var entity = await manager.CreateNewEntityAsync(dto);
        var res = await manager.AddAsync(entity);
        Assert.Equal(entity.Name, res.Name);

    }

    async internal Task Should_UpdateAsync()
    {
        var dto = new PollTagUpdateDto()
        {
            Name = "UpdateName" + RandomString,
            PollIssueId = new Guid(""),
        };
        var entity = await manager.Command.Db.FirstOrDefaultAsync();
        if (entity != null)
        {
            var res = await manager.UpdateAsync(entity, dto);
            Assert.Equal(entity.Name, res.Name);

        }
    }

    async internal Task Should_QueryAsync()
    {
        var filter = new PollTagFilterDto()
        {
            PageIndex = 1,
            PageSize = 2
        };
        var res = await manager.FilterAsync(filter);
        Assert.True(res != null && res.Count != 0 && res.Data.Count <= 2);
    }
}
