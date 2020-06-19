using kolokwium1.DTOs.Requests;
using kolokwium1.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium1.DAL
{
    public interface IDbService
    {
        TeamMemberResponse GetTeamMember(int id);

        TaskResponse UpdateTask(TaskRequest request);
        
    }
}
