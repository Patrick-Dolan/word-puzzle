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
      Console.WriteLine("Answer: " + newPuzzle.Solution);
      foreach (char c in newPuzzle.SolutionArr)
      {
        Console.WriteLine("Character: " + c);
      } 
      return View();
    }
  }
}