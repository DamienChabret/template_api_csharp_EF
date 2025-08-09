using api.models;
using api.services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
   [ApiController]
   [Route("example")]
   public class ExampleController : ControllerBase
   {

      [HttpGet]
      public async ActionResult GetAll()
      {
         return ok();
      }
   }
}
