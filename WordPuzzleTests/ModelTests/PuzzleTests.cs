using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WordPuzzle.Models;

namespace WordPuzzle.Tests
{
  [TestClass]
  public class PuzzleTests 
  {
    [TestMethod]
    public void Puzzle_CreatesInstanceOfPuzzle_Puzzle()
    {
      Puzzle newPuzzle = new Puzzle();
      Assert.AreEqual(typeof(Puzzle), newPuzzle.GetType());
    }

    [TestMethod]
    public void AssignSolution_AssignSolutionToPuzzleObject_Void()
    {
      // Arrange
      List<string> randomWordList = new List<string>
      {
        "apple", "beach", "carve", "daisy", "eagle", "flame", "globe", "honey",
        "image", "jolly", "knock", "lemon", "mango", "ninja", "olive", "piano",
        "quack", "raven", "shark", "tulip", "umbra", "vivid", "waltz", "xenon",
        "yacht"
      };
      Puzzle newPuzzle = new Puzzle();

      // Act
      bool result = randomWordList.Contains(newPuzzle.Solution);

      // Assert
      Assert.AreEqual(true, result);
    }

    [TestMethod]
    public void MakeGuess_ReturnFalseIfGuessIsWrong_False()
    {
      // Arrange
      Puzzle newPuzzle = new Puzzle();
      string guess = "wrong";

      // Act
      bool result = newPuzzle.MakeGuess(guess);

      // Assert
      Assert.AreEqual(false, result);
    }

    [TestMethod]
    public void MakeGuess_ReturnTrueIfGuessIsCorrect_True()
    {
      // Arrange
      Puzzle newPuzzle = new Puzzle();
      string guess = newPuzzle.Solution;

      // Act
      bool result = newPuzzle.MakeGuess(guess);

      // Assert
      Assert.AreEqual(true, result);
    }

    [TestMethod]
    public void MakeGuess_MakeGuessIncreasesNumberOfGuessesCounter_Bool()
    {
      // Arrange
      Puzzle newPuzzle = new Puzzle();
      string guess = newPuzzle.Solution;
      int numberOfGuesses = 1;
      
      // Act
      bool guessBool = newPuzzle.MakeGuess(guess);
      int result = newPuzzle.NumberOfGuesses;
      
      // Assert
      Assert.AreEqual(numberOfGuesses, result);
    }
  }
}