using kolokwium1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace kolokwium1.DTOs.Responses
{
    public class TeamMemberResponse
    {

        public int IdTeamMember { get; set; }
        public List<Task> Tasks { get; set; }

    }
}
