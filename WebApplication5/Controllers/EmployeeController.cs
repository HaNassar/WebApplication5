using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;
using WebApplication5.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IStore store;
        public EmployeeController()
        {
            this.store = new SqlStore();
        }
        [HttpPost()]
        public ActionResult<SubmissionResponse> SaveEmployye([FromBody] Employee employee)
        {
            if (employee == null || string.IsNullOrWhiteSpace(employee.Name))
            {
                return BadRequest(new SubmissionResponse
                {
                    Success = false,
                    ErrorCode = "Invalid Model"
                });
            }

            //save implementation
            employee.ID = Guid.NewGuid();
            var submissionResult = store.SaveEmployee(employee);
            if (!submissionResult.Success)
            {
                return BadRequest(submissionResult);
            }
            return Ok(submissionResult);
        }
    }
}
