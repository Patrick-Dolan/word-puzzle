using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WordPuzzle.Models;

namespace WordPuzzle.Tests
{
  [TestClass]
  public class PuzzleTests : IDisposable
  {
    public void Dispose()
    {
      Puzzle.ClearAll();
    }

    [TestMethod]
    public void Puzzle_CreatesInstanceOfPuzzle_Puzzle()
    {
      Puzzle newPuzzle = new Puzzle();
      Assert.AreEqual(typeof(Puzzle), newPuzzle.GetType());
    }

    [TestMethod]
    public void Find_FindAndReturnPuzzle_Puzzle()
    {
      // Arrange
      Puzzle newPuzzle1 = new Puzzle();
      Puzzle newPuzzle2 = new Puzzle();

      // Act
      Puzzle result = Puzzle.Find(2);

      // Assert
      Assert.AreEqual(newPuzzle2, result);
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

    [TestMethod]
    public void SetUpGuessIndicators_MarkListIndicesAsCorrectWhenGuessMatchesSolution_Void()
    {
      // Arrange
      Puzzle newPuzzle = new Puzzle();
      string guess = "mmmam";
      newPuzzle.Solution = "break";
      
      // Act
      newPuzzle.SetUpGuessIndicators(guess);
      List<string> expectedResult = new List<string> {"wrong", "wrong", "wrong", "correct", "wrong"};
      List<string> result = newPuzzle.GuessIndicators[0];

      // Assert
      CollectionAssert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void SetUpGuessIndicators_MarkListIndicesAsCorrectLetterWrongPositionAppropriately_Void()
    {
      // Arrange
      Puzzle newPuzzle = new Puzzle();
      string guess = "mammm";
      newPuzzle.Solution = "break";
      
      // Act
      newPuzzle.SetUpGuessIndicators(guess);
      List<string> expectedResult = new List<string> {"wrong", "correct-letter-wrong-position", "wrong", "wrong", "wrong"};
      List<string> result = newPuzzle.GuessIndicators[0];

      // Assert
      CollectionAssert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void SetUpGuessIndicators_MarkListIndicesAsCorrectAndCorrectLetterWrongPosition_Void()
    {
      // Arrange
      Puzzle newPuzzle = new Puzzle();
      string guess = "smack";
      newPuzzle.Solution = "break";
      
      // Act
      newPuzzle.SetUpGuessIndicators(guess);
      List<string> expectedResult = new List<string> {"wrong", "wrong", "correct-letter-wrong-position", "wrong", "correct"};
      List<string> result = newPuzzle.GuessIndicators[0];

      foreach (string indicator in result)
      {
        Console.WriteLine(indicator);
      }

      // Assert
      CollectionAssert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void SetUpGuessIndicators_OnlyIncludeNumberOfRepeatedLettersAsManyTimesAsItAppearsInSolution_Void()
    {
      // Arrange
      Puzzle newPuzzle = new Puzzle();
      string guess = "aaamm";
      newPuzzle.Solution = "breaa";
      
      // Act
      newPuzzle.SetUpGuessIndicators(guess);
      List<string> expectedResult = new List<string> {"correct-letter-wrong-position", "correct-letter-wrong-position", "wrong", "wrong", "wrong"};
      List<string> result = newPuzzle.GuessIndicators[0];

      foreach (string letter in result)
      {
        Console.WriteLine(letter);
      }

      // Assert
      CollectionAssert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    public void SetUpGuessIndicators_MarkDuplicateLettersOnlyAsManyTimesAsTheyShowEvenWhenOneIsCorrectlyPositioned_Void()
    {
      // Arrange
      Puzzle newPuzzle = new Puzzle();
      string guess = "aamam";
      newPuzzle.Solution = "breaa";
      
      // Act
      newPuzzle.SetUpGuessIndicators(guess);
      List<string> expectedResult = new List<string> {"correct-letter-wrong-position", "wrong", "wrong", "correct", "wrong"};
      List<string> result = newPuzzle.GuessIndicators[0];

      foreach (string letter in result)
      {
        Console.WriteLine(letter);
      }

      // Assert
      CollectionAssert.AreEqual(expectedResult, result);
    }
  }
}