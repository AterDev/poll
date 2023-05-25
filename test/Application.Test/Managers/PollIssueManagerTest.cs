using Application.IManager;
using Core.Entities.PollEntities;
using Core.Utils;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Share.Models.PollIssueDtos;

namespace Application.Test.Managers;

public class PollIssueManagerTest : BaseTest
{
    private readonly IPollIssueManager manager;
    public string RandomString { get; set; }

    public PollIssueManagerTest(WebApplicationFactory<Program> factory) : base(factory)
    {
        manager = Services.GetRequiredService<IPollIssueManager>();
        RandomString = DateTime.Now.ToString("MMddmmss");
    }
    [Fact]
    public async Task PollIssue_Should_Pass()
    {
        await Shoud_AddAsync();
        await Should_UpdateAsync();
        await Should_QueryAsync();
    }

    async internal Task Shoud_AddAsync()
    {
        var dto = new PollIssueAddDto()
        {
            IssueNo = "IssueNo" + RandomString,
            Title = "Title" + RandomString,
            Description = "Description" + RandomString,
            PollType = 0,
            
            
        };
        var entity = await manager.CreateNewEntityAsync(dto);
        var res = await manager.AddAsync(entity);
        Assert.Equal(entity.IssueNo, res.IssueNo);
        Assert.Equal(entity.Title, res.Title);
        Assert.Equal(entity.Description, res.Description);
        Assert.Equal(entity.PollType, res.PollType);
        Assert.Equal(entity.EffectiveStartDate, res.EffectiveStartDate);
        Assert.Equal(entity.EffectiveEndDate, res.EffectiveEndDate);

    }

    async internal Task Should_UpdateAsync()
    {
        var dto = new PollIssueUpdateDto()
        {
            IssueNo = "UpdateIssueNo" + RandomString,
            Title = "UpdateTitle" + RandomString,
            Description = "UpdateDescription" + RandomString,
            PollType = 0,
            
            
        };
        var entity = await manager.Command.Db.FirstOrDefaultAsync();
        if (entity != null)
        {
            var res = await manager.UpdateAsync(entity, dto);
            Assert.Equal(entity.IssueNo, res.IssueNo);
            Assert.Equal(entity.Title, res.Title);
            Assert.Equal(entity.Description, res.Description);
            Assert.Equal(entity.PollType, res.PollType);
            Assert.Equal(entity.EffectiveStartDate, res.EffectiveStartDate);
            Assert.Equal(entity.EffectiveEndDate, res.EffectiveEndDate);

        }
    }

    async internal Task Should_QueryAsync()
    {
        var filter = new PollIssueFilterDto()
        {
            PageIndex = 1,
            PageSize = 2
        };
        var res = await manager.FilterAsync(filter);
        Assert.True(res != null && res.Count != 0 && res.Data.Count <= 2);
    }
}
