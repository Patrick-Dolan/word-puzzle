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
      int randomNumber = random.Next(0, 25);
      return randomWordList[randomNumber];
    }

    public void SetUpGuessIndicators(string guess)
    {
      List<char> guessList = guess.ToCharArray().ToList();
      List<char> solutionList = Solution.ToCharArray().ToList();
      Dictionary<char, int> solutionLetterCounts = new Dictionary<char, int>();
      Dictionary<char, int> guessLetterCounts = new Dictionary<char, int>();

      // Count each letter in solution list
      for (int i = 0; i < solutionList.Count; i++)
      {
        if (!solutionLetterCounts.ContainsKey(solutionList[i]))
        {
          solutionLetterCounts.Add(solutionList[i], 0);
        }

        int count = 0;
        for (int j = 0; j < solutionList.Count; j++)
        {
          if (solutionList[i] == solutionList[j])
          {
            count++;
          }
        }
        solutionLetterCounts[solutionList[i]] = count;
      }

      // Count each letter in guess list
      for (int i = 0; i < guessList.Count; i++)
      {
        if (!guessLetterCounts.ContainsKey(guessList[i]))
        {
          guessLetterCounts.Add(guessList[i], 0);
        }

        int count = 0;
        for (int j = 0; j < guessList.Count; j++)
        {
          if (guessList[i] == guessList[j] && guessList[j] != solutionList[j])
          {
            count++;
          }
        }
        guessLetterCounts[guessList[i]] = count;
      }

      // Find correct letters
      List<string> tempGuessIndicators = new List<string> { "wrong", "wrong", "wrong", "wrong", "wrong" };
      for (int i = 0; i < tempGuessIndicators.Count; i++)
      {
        if (solutionList[i] == guessList[i])
        {
          tempGuessIndicators[i] = "correct";
        } 
        else if (solutionList.Contains(guessList[i]) && tempGuessIndicators[i] != "correct")
        {
          if (guessLetterCounts[guessList[i]] >= solutionLetterCounts[guessList[i]])
          {
            solutionLetterCounts[guessList[i]]++;
            tempGuessIndicators[i] = "correct-letter-wrong-position";
          }
        }
      }

      GuessIndicators[NumberOfGuesses] = tempGuessIndicators;
    }

    public void MakeGuess(string guess)
    {
      // Add guess to list of guesses
      string lowercasedGuess = guess.ToLower();
      Guesses.Add(lowercasedGuess.ToCharArray().ToList());

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