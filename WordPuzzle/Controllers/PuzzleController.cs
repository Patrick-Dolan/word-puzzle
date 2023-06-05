using Microsoft.AspNetCore.Mvc;
using System;
using WordPuzzle.Models;

namespace WordPuzzle.Controllers
{
  public class PuzzleController : Controller
  {
    [HttpGet("/puzzle")]
    public ActionResult Index()
    {
      Puzzle newPuzzle = new Puzzle();
      
      // TODO REMOVE DEBUG TOOLS 
      // =================================================
      Console.WriteLine("Answer: " + newPuzzle.Solution);
      // =================================================

      return View(newPuzzle);
    }

    [HttpPost("/puzzle")]
    public ActionResult Index(string userGuess, int searchId)
    {
      Puzzle foundPuzzle = Puzzle.Find(searchId);
      foundPuzzle.MakeGuess(userGuess);
      
      // TODO REMOVE DEBUG TOOLS 
      // =================================================
      Console.WriteLine("User guess: " + userGuess);
      Console.WriteLine("User guess count: " + foundPuzzle.NumberOfGuesses);
      Console.WriteLine("User guess count from list: " + foundPuzzle.Guesses.Count);
      // =================================================

      return View(foundPuzzle);
    }
  }
}