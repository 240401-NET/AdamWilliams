using memoKeeper;


namespace memoKeeperApp.Tests;

public class MemoManipulationTests
{
    [Theory]
    [InlineData("blah", "blah blah blah")]
    
    public void MemoManipulation_createMemoTest_CreatesNewNotNullMemo(string title, string message)
    {
        //Arrange

        
        //Act

        Memo m = MemoManipulation.createMemo(title, message);

        //Assert

        Assert.NotNull(m);

    }


    [Theory]
    [InlineData("blah", "blah blah blah")]
    [InlineData("test", "test message")]
    [InlineData("testing", "message 2")]
    [InlineData("hmm", "is it working?")]
    public void MemoManipulation_createMemo_AddsTitle(string title, string message){

        //Arrange

        //Act

        Memo m = MemoManipulation.createMemo(title, message);

        //Assert

        Assert.Equal(title,m.title);

    }

    [Theory]
    [InlineData("blah", "blah blah blah")]
    [InlineData("test", "test message")]
    [InlineData("testing", "message 2")]
    [InlineData("hmm", "is it working?")]
    public void MemoManipulation_createMemo_AddsDate(string title, string message){

        //Arrange

        //Act

        Memo m = MemoManipulation.createMemo(title, message);

        //Assert

        Assert.Equal(DateTime.Now.ToShortDateString(),m.date);

    }

    [Theory]
    [InlineData("blah", "blah blah blah")]
    [InlineData("test", "test message")]
    [InlineData("testing", "message 2")]
    [InlineData("hmm", "is it working?")]
    public void MemoManipulation_createMemo_AddsMessage(string title, string message){

        //Arrange

        //Act

        Memo m = MemoManipulation.createMemo(title, message);

        //Assert

        Assert.Equal(message,m.message);

    }
}