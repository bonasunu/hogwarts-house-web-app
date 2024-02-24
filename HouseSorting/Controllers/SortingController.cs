using Microsoft.AspNetCore.Mvc;

namespace HouseSorting.Controllers;

public class SortingController : Controller
{
  public IActionResult Index(string name)
  {
    if (!ModelState.IsValid || String.IsNullOrEmpty(name))
    {
      return BadRequest(ModelState);
    }

    string[] houses = ["Gryffindor", "Hufflepuff", "Ravenclaw", "Slytherin"];
    Random random = new();
    var randomIndex = random.Next(houses.Length);
    ViewData["house"] = houses[randomIndex];
    ViewData["name"] = name;

    return View();
  }
}