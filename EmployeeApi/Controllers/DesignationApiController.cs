using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using Repository_Layer;
using System.Data.Entity;

namespace EmployeeApi.Controllers
{
    public class DesignationApiController : Controller
    {
        private readonly AppDBcontext _employeeContext;

        public DesignationApiController(AppDBcontext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        [HttpPost]
        [Route("designation")]
        public IActionResult designation([FromBody] Designation designation1)
        {
            if (!ModelState.IsValid)
                return BadRequest("not a valid request");
            _employeeContext.DesignationTypes.Add(designation1);
            _employeeContext.SaveChanges();
            return Ok();
        }


        [HttpGet]
        public List<Designation> Get()
        {
            return _employeeContext.DesignationTypes.ToList();
            //var data = _employeeContext.employee.Include(c => c.designations).ToList();
            //return Ok(data);
        }
    }

}
