using HouseSorting.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HouseSorting.Tests;

public class SortingControllerTests
{
  [Fact]
  public void Index_ReturnsAViewResult_WithHouseInformation()
  {
    var controller = new SortingController();
    var result = controller.Index("Jorge Potter") as ViewResult;
    string[] houses = ["Gryffindor", "Hufflepuff", "Ravenclaw", "Slytherin"];
    var house = result!.ViewData["house"] as string;

    Assert.IsType<ViewResult>(result);
    Assert.Contains(house, houses);
  }

  [Fact]
  public void IndexPost_ReturnsBadRequestResult_WhenModelStateIsInvalid()
  {
    var controller = new SortingController();
    var result = controller.Index(String.Empty);
    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
    Assert.IsType<SerializableError>(badRequestResult.Value);
  }
}