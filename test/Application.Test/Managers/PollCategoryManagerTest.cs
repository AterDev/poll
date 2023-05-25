using Application.IManager;
using Core.Entities.PollEntities;
using Core.Utils;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Share.Models.PollCategoryDtos;

namespace Application.Test.Managers;

public class PollCategoryManagerTest : BaseTest
{
    private readonly IPollCategoryManager manager;
    public string RandomString { get; set; }

    public PollCategoryManagerTest(WebApplicationFactory<Program> factory) : base(factory)
    {
        manager = Services.GetRequiredService<IPollCategoryManager>();
        RandomString = DateTime.Now.ToString("MMddmmss");
    }
    [Fact]
    public async Task PollCategory_Should_Pass()
    {
        await Shoud_AddAsync();
        await Should_UpdateAsync();
        await Should_QueryAsync();
    }

    async internal Task Shoud_AddAsync()
    {
        var dto = new PollCategoryAddDto()
        {
            Name = "Name" + RandomString,
        };
        var entity = await manager.CreateNewEntityAsync(dto);
        var res = await manager.AddAsync(entity);
        Assert.Equal(entity.Name, res.Name);

    }

    async internal Task Should_UpdateAsync()
    {
        var dto = new PollCategoryUpdateDto()
        {
            Name = "UpdateName" + RandomString,
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
        var filter = new PollCategoryFilterDto()
        {
            PageIndex = 1,
            PageSize = 2
        };
        var res = await manager.FilterAsync(filter);
        Assert.True(res != null && res.Count != 0 && res.Data.Count <= 2);
    }
}
