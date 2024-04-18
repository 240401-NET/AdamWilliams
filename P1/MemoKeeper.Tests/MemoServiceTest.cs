using Moq;
using MemoKeeper.Data;
using MemoKeeper.Models;
using MemoKeeper.Services;
using MemoKeeper.API;
using Microsoft.AspNetCore.Mvc.Diagnostics;


namespace MemoKeeper.Tests;

public class MemoServiceTest
{
    [Fact]
    public void MemoService_GetAllMemos_returnsMemoList()
    {
        //Arrange
        Mock<IRepository> repoMock = new Mock<IRepository>();
        List<Memo> fakeMemos = 
        [
            new Memo{
                Id=1,
                Title="test",
                Date="4/17/2024",
                Message="This is a test."
            }
        ];
        repoMock.Setup(repo => repo.GetAllMemos()).Returns(fakeMemos);
        MemoService service = new MemoService(repoMock.Object);

        //Act
        IEnumerable<Memo> allMemos = service.GetAllMemos();

        //Assert
        Assert.Single(allMemos);
        repoMock.Verify(repo => repo.GetAllMemos(), Times.Exactly(1));
    }

    [Theory]
    [InlineData("date")]
    [InlineData("December 12, 2012")]
    [InlineData("00")]
    [InlineData("00000000")]
    [InlineData("15/01/2024")]
    [InlineData("12/40/2015")]
    [InlineData("12/10/15015")]
    public void MemoService_GetMemoByDate_NotAllowInvalidDate(string date)
    {
        //Arrange
        Mock<IRepository> repoMock = new Mock<IRepository>();
        MemoService service = new MemoService(repoMock.Object);

        //Act


        //Assert
        Assert.Throws<FormatException>(() => service.GetMemoByDate(date));
        repoMock.Verify(repo => repo.GetMemoByDate(date), Times.Exactly(0));
    }

    [Theory]
    [InlineData ("04/04/2024")]
    [InlineData ("03/01/1492")]
    [InlineData ("9/11/2001")]
    [InlineData ("4/4/2000")]
    [InlineData ("07/4/1985")]
    [InlineData ("10/04/2010")]
    public void MemoService_GetMemoByDate_ShouldAllowValidDate(string date)
    {
        // Arrange
        Mock<IRepository> repoMock = new Mock<IRepository>();

        List<Memo> fakeMemo = [
            new Memo{
                Id = 1,
                Title = "Test",
                Date = date,
                Message = "This is message."
            }
        ];

        repoMock.Setup(repo => repo.GetMemoByDate(date)).Returns(fakeMemo);
        MemoService service = new MemoService(repoMock.Object);

        //Act
        IEnumerable<Memo> allPets = service.GetMemoByDate(date);

        //Assert
        Assert.Single(allPets);
    }

    [Theory]
    [InlineData (1)]
    [InlineData (2)]
    [InlineData (3)]
    public void MemoService_GetMemoById_ShouldReturnCorrectMemo(int id)
    {
        //Arrange
        Mock<IRepository> repoMock = new Mock<IRepository>();

        List<Memo> fakeMemo = [
            new Memo{
                Id = 1,
                Title = "Test1",
                Date = "12/12/2012",
                Message = "This is message 1."
            },
            new Memo{
                Id = 2,
                Title = "Test2",
                Date = "12/12/2012",
                Message = "This is message 2."
            },
            new Memo{
                Id = 3,
                Title = "Test3",
                Date = "12/12/2012",
                Message = "This is message 3."
            }
        ];   

        repoMock.Setup(repo => repo.GetMemoById(id)).Returns(fakeMemo[id-1]);
        MemoService service = new MemoService(repoMock.Object);

        //Act
        Memo memo = service.GetMemoById(id);

        //Assert
        Assert.Equal(fakeMemo[id-1],memo);
    }

    [Fact]
    public void MemoService_CreateNewMemo_ReturnsMemo()
    {
                //Arrange
        Mock<IRepository> repoMock = new Mock<IRepository>();

        Memo memo =  new Memo{
                Id = 4,
                Title = "New Memo",
                Date = "12/12/2012",
                Message = "This is the new memo."
            };  

        repoMock.Setup(repo => repo.CreateNewMemo(memo)).Returns(memo);
        MemoService service = new MemoService(repoMock.Object);

        //Act
        Memo returnedMemo = service.CreateNewMemo(memo);

        //Assert
        Assert.True(returnedMemo is not null);
        Assert.Equal(returnedMemo, memo);
    }
}