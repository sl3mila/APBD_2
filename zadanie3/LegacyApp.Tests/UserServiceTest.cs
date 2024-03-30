using System;
using JetBrains.Annotations;
using Xunit;

namespace LegacyApp.Tests;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{

    [Fact]
    public void AddUser_Should_Return_False_When_FirstName_Is_Missing()
    {
        // Arrange - przytowanie zależności do testu
        var userService = new UserService();
        
        // Act - wywołanie testowanej funkcjonalności
        var addResult = userService.AddUser("", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        
        // Assert - sprawdzenie wyniku
        //Assert.Equal(false, addResult);
        Assert.False(addResult);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Last_Name_Is_Missing()
    {
        // Arrange - przytowanie zależności do testu
        var userService = new UserService();
        
        // Act - wywołanie testowanej funkcjonalności
        var addResult = userService.AddUser("John", "", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        
        // Assert - sprawdzenie wyniku
        Assert.False(addResult);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Email_Do_Not_Have_At()
    {
        // Arrange - przytowanie zależności do testu
        var userService = new UserService();
        
        // Act - wywołanie testowanej funkcjonalności
        var addResult = userService.AddUser("John", "Doe", "johndoegmail.com", DateTime.Parse("1982-03-21"), 1);
        
        // Assert - sprawdzenie wyniku
        Assert.False(addResult);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Email_Do_Not_Have_Point()
    {
        // Arrange - przytowanie zależności do testu
        var userService = new UserService();
        
        // Act - wywołanie testowanej funkcjonalności
        var addResult = userService.AddUser("John", "Doe", "johndoe@gmailcom", DateTime.Parse("1982-03-21"), 1);
        
        // Assert - sprawdzenie wyniku
        Assert.False(addResult);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Age_Lower_Than_21()
    {
        // Arrange - przytowanie zależności do testu
        var userService = new UserService();
        
        // Act - wywołanie testowanej funkcjonalności
        var addResult = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("2005-03-21"), 1);
        
        // Assert - sprawdzenie wyniku
        Assert.False(addResult);
    }
    
    [Fact]
    public void AddUser_Should_Throw_Argument_Exception_When_Client_Id_Is_Not_Existing()
    {
        // Arrange - przytowanie zależności do testu
        var userService = new UserService();
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var addResult = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 20);

        });
    }
    
    [Fact]
    public void AddUser_Should_Throw_Argument_Exception_When_Last_Name_Is_Not_Existing()
    {
        // Arrange - przytowanie zależności do testu
        var userService = new UserService();
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() =>
        {
            var addResult = userService.AddUser("John", "Michelle", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);

        });
    }
    
    [Fact]
    public void AddUser_Should_Return_False_If_Credit_Limit()
    {
        // Arrange - przytowanie zależności do testu
        var userService = new UserService();
        
        // Act - wywołanie testowanej funkcjonalności
        var addResult = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("2005-03-21"), 2);
        
        // Assert - sprawdzenie wyniku
        Assert.False(addResult);
    }
    
}