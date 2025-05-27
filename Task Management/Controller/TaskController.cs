using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Model;

namespace Task_Management.Controller
{
    public class TaskController
    {
        public List<Taskk> tasks;

        public TaskController()
        {
            tasks = GetTasksFromDatabase();
        }
        internal void AddTask(Taskk t)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=db_task_management;Integrated Security=True;";
            string query = "INSERT INTO tb_task (Name, Date, Status) VALUES (@Name, @Date, @Status)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", t.Name);
                    cmd.Parameters.AddWithValue("@Date", t.Date);
                    cmd.Parameters.AddWithValue("@Status", t.Status);

                    cmd.ExecuteNonQuery();
                }
            }

            tasks.Add(t);
        }

        internal void RemoveTask(Taskk task)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=db_task_management;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM tb_task WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", task.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Taskk> GetTasksFromDatabase()
        {
            var tasks = new List<Taskk>();
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=db_task_management;Integrated Security=True;";
            string query = "SELECT Name, Date, Status FROM tb_task";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        DateTime date = Convert.ToDateTime(reader["Date"]);
                        string status = reader["Status"].ToString();

                        tasks.Add(new Taskk(name, date, status));
                    }
                }
            }
            return tasks;
        }

        public void UpdateTask(Taskk task)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=db_task_management;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE tb_task SET name = @name, date = @date, status = @status WHERE id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", task.Name);
                    cmd.Parameters.AddWithValue("@date", task.Date);
                    cmd.Parameters.AddWithValue("@status", task.Status);
                    cmd.Parameters.AddWithValue("@id", task.Id); // certifique-se de ter o ID

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void LoadTasksFromDatabase()
        {
            tasks.Clear();

            string connectionString = @"Server=localhost\SQLEXPRESS;Database=db_task_management;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT id, name, date, status FROM tb_task";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Taskk task = new Taskk(
                            reader.GetInt32(0),               
                            reader.GetString(1),
                            reader.GetDateTime(2),
                            reader.GetString(3)                
                        );

                        tasks.Add(task);
                    }
                }
            }
        }
    }
}
