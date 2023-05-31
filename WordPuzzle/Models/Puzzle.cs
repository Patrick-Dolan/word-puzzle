using System;
using System.Collections.Generic;
using System.Linq;

namespace WordPuzzle.Models
{
  public class Puzzle
  {
    public string Solution { get; set; }
    public int NumberOfGuesses { get; set; } = 0;
    public int MaximumNumberOfGuesses { get; } = 6;
    public bool GameOver { get; set; }
    public bool Win { get; set; }
    public List<char> SolutionArr { get; set; }

    public Puzzle()
    {
      Solution = this.AssignSolution();
      SolutionArr = Solution.ToCharArray().ToList();
    }

    private string AssignSolution()
    {
      // Random word count: 25
      List<string> randomWordList = new List<string>
      {
        "apple", "beach", "carve", "daisy", "eagle", "flame", "globe", "honey",
        "image", "jolly", "knock", "lemon", "mango", "ninja", "olive", "piano",
        "quack", "raven", "shark", "tulip", "umbra", "vivid", "waltz", "xenon",
        "yacht"
      };

      // Generate random index number for list
      Random random = new Random();
      int randomNumber = random.Next(0, 25);
      return randomWordList[randomNumber];
    }

    public void MakeGuess(string guess)
    {
      // Increase guess counter
      NumberOfGuesses++;
      
      string lowercasedGuess = guess.ToLower();
      if (lowercasedGuess == Solution)
      {
        Win = true;
        GameOver = true;
      }

      if (NumberOfGuesses >= MaximumNumberOfGuesses)
      {
        GameOver = true;
      }
    }
  }
}