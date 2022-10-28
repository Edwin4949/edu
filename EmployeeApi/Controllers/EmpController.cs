using Microsoft.AspNetCore.Mvc;
using ModelLayer;
//using Repository_Layer;
using Business_Logic_Layer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmployee _Context;
        public EmpController(IEmployee context)
        {
            _Context = context;
        }

        // GET: api/<EmpController>
        [HttpGet("Get")]
       
        public ActionResult<List<EmployeeRegistration>> Get()
        {
            var result = _Context.Get();
            return _Context.Get();
        }
        [HttpPost]
        [Route("post")]

        public IActionResult Post([FromBody] EmployeeRegistration empl)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid");
            _Context.Post(empl);
            return Ok();
        }
        [HttpDelete]
        [Route("delete/{UserName}")]
        public ActionResult Delete(string UserName)
        {
            
            _Context.Delete(UserName);
            return Ok();
        }

    }
}
