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
    public List<List<char>> Guesses { get; set; } = new List<List<char>>();
    public int Id { get; }
    public static List<Puzzle> _instances = new List<Puzzle>();

    public Puzzle()
    {
      Solution = this.AssignSolution();
      SolutionArr = Solution.ToCharArray().ToList();
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Puzzle Find(int searchId)
    {
      return _instances[searchId - 1];
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

      // Add guess to list of guesses
      string lowercasedGuess = guess.ToLower();
      Guesses.Add(lowercasedGuess.ToCharArray().ToList());

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