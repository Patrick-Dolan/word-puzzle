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
    public void MakeGuess_SetWinToTrueIfGuessIsCorrect_Void()
    {
      // Arrange
      Puzzle newPuzzle = new Puzzle();
      string guess = newPuzzle.Solution;

      // Act
      newPuzzle.MakeGuess(guess);
      bool result = newPuzzle.Win;

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
      newPuzzle.MakeGuess(guess);
      int result = newPuzzle.NumberOfGuesses;
      
      // Assert
      Assert.AreEqual(numberOfGuesses, result);
    }

    [TestMethod]
    public void MakeGuess_SetGameOverToTrueWhenNumberOfGuessesReachesMaximumNumberOfGuesses_Void()
    {
      // Arrange 
      Puzzle newPuzzle = new Puzzle();
      string wrongGuess = "aaaaa";

      // Act
      for ( int i = 0; i <= newPuzzle.MaximumNumberOfGuesses - 1; i++)
      {
        newPuzzle.MakeGuess(wrongGuess);
      }
      bool result = newPuzzle.GameOver;

      // Assert
      Assert.AreEqual(true, result);
    }

    [TestMethod]
    public void MakeGuess_AddNewGuessToListOfGuesses_Void()
    {
      // Arrange 
      Puzzle newPuzzle = new Puzzle();
      string guess = "aaaaa";
      List<char> guessList = new List<char> { 'a', 'a', 'a', 'a', 'a' };

      // Act
      newPuzzle.MakeGuess(guess);
      List<char> result = newPuzzle.Guesses[0];

      // Assert
      CollectionAssert.AreEqual(guessList, result);
    }

    [TestMethod]
    public void MakeGuess_SaveMultipleNewGuessToListOfGuesses_Void()
    {
      // Arrange 
      Puzzle newPuzzle = new Puzzle();
      string guess = "aaaaa";

      // Act
      newPuzzle.MakeGuess(guess);
      newPuzzle.MakeGuess(guess);
      int result = newPuzzle.Guesses.Count;

      // Assert
      Assert.AreEqual(2, result);
    }
  }
}