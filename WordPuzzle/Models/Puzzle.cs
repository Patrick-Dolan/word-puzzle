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
    public List<List<char>> Guesses { get; set; } = new List<List<char>>();
    public List<List<string>> GuessIndicators { get; set; } = new List<List<string>>()
    {
      new List<string>() {"wrong", "wrong", "wrong", "wrong", "wrong"},
      new List<string>() {"wrong", "wrong", "wrong", "wrong", "wrong"},
      new List<string>() {"wrong", "wrong", "wrong", "wrong", "wrong"},
      new List<string>() {"wrong", "wrong", "wrong", "wrong", "wrong"},
      new List<string>() {"wrong", "wrong", "wrong", "wrong", "wrong"},
      new List<string>() {"wrong", "wrong", "wrong", "wrong", "wrong"}
    };
    public int Id { get; }
    public static List<Puzzle> _instances = new List<Puzzle>();

    public Puzzle()
    {
      Solution = this.AssignSolution();
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
      int randomNumber = random.Next(0, randomWordList.Count);
      return randomWordList[randomNumber];
    }

    public void SetUpGuessIndicators(string guess)
    {
      Dictionary<char, int> count = new Dictionary<char, int>();
      List<string> result = new List<string> { "wrong", "wrong", "wrong", "wrong", "wrong" };

      for (int i = 0; i < guess.Length; i++)
      {
        if (Solution[i] == guess[i])
        {
          result[i] = "correct";
        }
        else
        {
          if (count.ContainsKey(Solution[i]))
          {
            count[Solution[i]]++;
          }
          else
          {
            count[Solution[i]] = 1;
          }
        }
      }

      for (int i = 0; i < guess.Length; i++)
      {
        if (Solution[i] == guess[i] || !count.ContainsKey(guess[i]) || count[guess[i]] == 0)
        {
          continue;
        }

        count[guess[i]]--;
        result[i] = "correct-letter-wrong-position";
      }

      GuessIndicators[NumberOfGuesses] = result;
    }

    public void MakeGuess(string guess)
    {
      // Add guess to list of guesses
      string lowercasedGuess = guess.ToLower();
      Guesses.Add(lowercasedGuess.ToCharArray().ToList());
      this.SetUpGuessIndicators(lowercasedGuess);

      // Increase guess counter
      NumberOfGuesses++;

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