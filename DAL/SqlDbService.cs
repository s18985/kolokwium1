using kolokwium1.DTOs.Requests;
using kolokwium1.DTOs.Responses;
using kolokwium1.Models;
using System.Data.SqlClient;

namespace kolokwium1.DAL
{
    public class SqlDbService : IDbService
    {
        public TeamMemberResponse GetTeamMember(int id)
        {
            const string ConString = "Data Source=db-mssql;Initial Catalog=s18985;Integrated Security=True";
            TeamMemberResponse response = new TeamMemberResponse();
            response.IdTeamMember = id;

            using (var con = new SqlConnection(ConString))
            using (var com = new SqlCommand())
            {
                com.Connection = con;

                con.Open();

                com.CommandText = "select * from task inner join teammember on task.idassignedto = teammember.idteammember inner join TaskType on task.IdTaskType = TaskType.IdTaskType where idteammember = @id";
                com.Parameters.AddWithValue("id", id);
                var dr = com.ExecuteReader();

                while (dr.Read())
                {
                    Task task = new Task();
                    task.IdTask = (int) dr["IdTask"];
                    task.TaskType = dr["Name"].ToString();

                    if((int)dr["idassignedto"] == (int)dr["idcrator"])
                    {
                        task.Creator = true;
                    }
                    else
                    {
                        task.Creator = false;
                    }
                    response.Tasks.Add(task);
                }

            }
            return response;
        }

        public TaskResponse UpdateTask(TaskRequest request)
        {
            const string ConString = "Data Source=db-mssql;Initial Catalog=s18985;Integrated Security=True";

            using (var con = new SqlConnection(ConString))
            using (var com = new SqlCommand())
            {
                com.Connection = con;

                con.Open();
            }
            return null;
        }

    }
}
