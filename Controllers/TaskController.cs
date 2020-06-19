using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using kolokwium1.DAL;
using kolokwium1.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium1.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {


        private IDbService _service;

        public TaskController(IDbService service)
        {
            _service = service;
        }

        [HttpGet("api/team-members/{id}/tasks")]
        public IActionResult GetTeamMember(TaskRequest request)
        {
            try
            {
                var response = _service.UpdateTask(request);

                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (SqlException exc)
            {
                return BadRequest();
            }
        }
    }
}