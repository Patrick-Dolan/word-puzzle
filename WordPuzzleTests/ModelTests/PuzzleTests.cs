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
      bool result = false;
      // Check if newPuzzle solution is included in possible words list
      randomWordList.ForEach((e) => {
        if (e == newPuzzle.Solution)
        {
          result = true;
        }
      });

      // Assert
      Assert.AreEqual(true, result);
    }
  }
}