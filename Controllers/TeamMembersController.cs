using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using kolokwium1.DAL;
using kolokwium1.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium1.Controllers
{
    [Route("api/team-members")]
    [ApiController]
    public class TeamMembersController : ControllerBase
    {

        private IDbService _service;

        public TeamMembersController(IDbService service)
        {
            _service = service;
        }

        [HttpGet("api/team-members/{id}")]
        public IActionResult GetTeamMember(int id)
        {

            try
            {
                var response = _service.GetTeamMember(id);

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