using System.Diagnostics.CodeAnalysis;
using memoKeeper;

namespace memoKeeperApp.Tests;

public class MenuBLTests
{

    [Theory]
    [InlineData(" ")]
    [InlineData("")]
    //[InlineData(null)]
    [InlineData("0")]
    public void MenuBL_getUserInput_ReturnsNotNullString(string consoleInput){
        //Arrange
        Console.SetIn(new StringReader(consoleInput));
        string expected = consoleInput ?? " ";
        if (consoleInput == ""){
            expected = " ";} 

        //Act
        string userInput = MenuBL.getUserInput();

        //Assert
        Assert.True(userInput!=null);
        Assert.Equal(expected, userInput);
        
    }

    [Theory]
    [InlineData("")]
    [InlineData("3")]
    [InlineData("2.4")]
    [InlineData(" ")]
    public void MenuBL_getIntUserInput_ReturnsInt(string userInput){
        //Arrange

        //Act
        var userIntInput = MenuBL.getIntUserInput(userInput);
        //Assert
        Assert.Equal(typeof(int), userIntInput.GetType());
    }

}