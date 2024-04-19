using Moq;
using MemoKeeper.Data;
using MemoKeeper.Models;
using MemoKeeper.Services;
using MemoKeeper.API;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using MemoKeeper.API.Controllers;
using Microsoft.Extensions.Caching.Memory;


namespace MemoKeeper.Tests;

public class MemoControllerTest
{
    [Fact]
    public void MemoController_GetAllMemos_ReturnsIEnum()
    {
        //Arrange
        Mock<IMemoService> serviceMock = new Mock<IMemoService>();
        var cache = new MemoryCache(new MemoryCacheOptions());
        
        IEnumerable<Memo> fakeMemos = 
        [
            new Memo{
                Id=1,
                Title="test",
                Date="4/17/2024",
                Message="This is a test."
            }
        ];

        serviceMock.Setup(s => s.GetAllMemos()).Returns(fakeMemos);
        MemoController controller = new MemoController(serviceMock.Object, cache);

        //Act
        IEnumerable<Memo> allMemos = controller.GetAllMemos();

        //Assert
        Assert.True(allMemos is not null);
        Assert.Equal(fakeMemos, allMemos);
    }
}