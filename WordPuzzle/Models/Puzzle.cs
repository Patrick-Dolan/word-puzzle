using System;
using System.Collections.Generic;

namespace WordPuzzle.Models
{
  public class Puzzle
  {
    public string Answer { get; set; }
    // Random Word
    public Puzzle()
    {
      Answer = this.AssignAnswer();
    }

    private string AssignAnswer()
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
  }
}