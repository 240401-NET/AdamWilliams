using System.Reflection;
using memoKeeper;


namespace memoKeeperApp.Tests;

public class MemoTests
{
    [Theory]
    [InlineData("blah", "blah blah blah")]
    
    public void Memo_createMemoTest_CreatesNewNotNullMemo(string title, string message)
    {
        //Arrange
        MemoController memoController = new();

        
        //Act

        Memo m = memoController.createMemo(title, message);

        //Assert

        Assert.NotNull(m);

    }


    [Theory]
    [InlineData("blah", "blah blah blah")]
    [InlineData("test", "test message")]
    [InlineData("testing", "message 2")]
    [InlineData("hmm", "is it working?")]
    public void Memo_createMemo_AddsTitle(string title, string message){

        //Arrange
        MemoController memoController = new();
        //Act

        Memo m = memoController.createMemo(title, message);

        //Assert

        Assert.Equal(title,m.Title);

    }

    [Theory]
    [InlineData("blah", "blah blah blah")]
    [InlineData("test", "test message")]
    [InlineData("testing", "message 2")]
    [InlineData("hmm", "is it working?")]
    public void MemoManipulation_createMemo_AddsDate(string title, string message){

        //Arrange
        MemoController memoController = new();
        //Act

        Memo m = memoController.createMemo(title, message);

        //Assert

        Assert.Equal(DateTime.Now.ToShortDateString(),m.Date);

    }

    [Theory]
    [InlineData("blah", "blah blah blah")]
    [InlineData("test", "test message")]
    [InlineData("testing", "message 2")]
    [InlineData("hmm", "is it working?")]
    public void MemoManipulation_createMemo_AddsMessage(string title, string message){

        //Arrange
        MemoController memoController = new();
        //Act

        Memo m = memoController.createMemo(title, message);

        //Assert

        Assert.Equal(message,m.Message);

    }

    [Theory]
    [InlineData("Memo", "4/4/2024", "Message", "New message")]
    [InlineData("Memo", "4/4/2024", "", "New message")]
    [InlineData("Memo", "4/4/2024", "Message", "")]
    public void Memo_editMemo_UpdatesMessage(string title, string date, string message, string newMessage){
        //Arrange
        MemoController memoController = new();
        Memo memo = new Memo(title, date, message);

        //Act
        memo = memoController.editMemo(memo,newMessage);
        //Assert
        Assert.Equal(newMessage, memo.Message);
    }

    // [Theory]
    // [InlineData("Memo", "4/4/2024", "Hello, World!")]
    // public void MemoManipulation_saveMemo_AddsMemoToList(string title, string date, string message){
    //     //Arrange
    //     Memo m = new(title, date, message);
    //     List<Memo> memos = new();
    //     int memosLength = memos.Count();
    //     Memo mEdit = new(title, date, message);
        
    //     //Act
    //     Memo.saveMemo(memos, ref m, mEdit);
        
    //     //Assert        
    //     Assert.True(memosLength < memos.Count());
    //     Assert.True(memos[0] != null);
    //     Assert.True(memos[0].Equals(m));
    // }

    // [Theory]
    // [InlineData("Memo", "4/4/2024", "Hello, World!", "Your mom!")]
    // [InlineData("Memo", "4/4/2024", "Hello, World!", "Hello, World!")]
    // public void MemoManipulation_saveMemo_UpdatesMemo(string title, string date, string message, string newMessage){
    //     //Arrange
    //     Memo m = new(title, date, message);
    //     List<Memo> memos = new() {m};
    //     Memo mEdit = new(title, date, newMessage);
        
    //     //Act
    //     Memo.saveMemo(memos, ref m, mEdit);
        
    //     //Assert        
    //     Assert.True(memos[0].message == mEdit.message);
    // }

    // [Fact]
    // public void Memo_deleteMemo_RemovesMemoFromList(){
    //     //Arrange
    //     Memo m1 = new();
    //     Memo m2 = new();
    //     Memo m3 = new();
    //     List<Memo> memos = new() {m1,m2,m3};
    //     int memosLength = memos.Count();

    //     //Act
    //     Memo.deleteMemo(ref memos, m1);

    //     //Assert
    //     Assert.True(memosLength > memos.Count());
    // }

}