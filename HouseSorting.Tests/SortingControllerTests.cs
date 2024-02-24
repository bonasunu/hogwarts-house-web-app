using HouseSorting.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HouseSorting.Tests;

public class SortingControllerTests
{
  [Fact]
  public void Index_ReturnsAViewResult_WithHouseInformation()
  {
    var controller = new SortingController();
    var result = controller.Index("Jorge Potter");
    Assert.IsType<ViewResult>(result);
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