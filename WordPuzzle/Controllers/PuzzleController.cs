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

      return View(newPuzzle);
    }

    [HttpPost("/puzzle")]
    public ActionResult Index(string userGuess, int searchId)
    {
      Puzzle foundPuzzle = Puzzle.Find(searchId);
      if (userGuess == null)
      {
        return View(foundPuzzle);
      }
      foundPuzzle.MakeGuess(userGuess);

      if (foundPuzzle.GameOver)
      {
        return RedirectToAction("GameOver", foundPuzzle);
      }
      else
      {
        return View(foundPuzzle);
      }
    }

    [HttpGet("/GameOver")]
    public ActionResult GameOver(Puzzle puzzle)
    {
      return View(puzzle);
    }
  }
}