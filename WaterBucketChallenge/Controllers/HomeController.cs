using Microsoft.AspNetCore.Mvc;
using WaterBucketChallenge.Models;
using WaterBucketChallenge.Service;

namespace WaterBucketChallenge.Controllers
{
    public class HomeController : Controller
    {
        private TestService _testService = new TestService();

        public IActionResult Index(TestValue value)
        {
            TestResult result = new TestResult();

            if (value.X > 0)
                result = _testService.Test(value.X, value.Y, value.Z);

            return View(result);
        }

        [HttpPostAttribute]
        public JsonResult Test([FromBody] TestValue value)
        {
            TestResult result = null;

            if(value.X > 0)
                result = _testService.Test(value.X, value.Y, value.Z, true);

            if (result == null) return new JsonResult("No Solution");

            return new JsonResult(result);
        }
    }
}
