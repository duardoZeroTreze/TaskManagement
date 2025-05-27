using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task_Management.Controller;
using Task_Management.Model;
using Task_Management.View;

namespace Task_Management
{
    public partial class Task_Management : Form
    {
        TaskController taskc = new TaskController();
        string connectionString = @"Server=localhost\SQLEXPRESS;Database=db_task_management;Integrated Security=True;";
        public Task_Management()
        {
            InitializeComponent();
            UpdateDataGridView();
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            string nome = txt_name.Text;
            DateTime date = dtp_date.Value;
            string status = "Pending";

            if (!string.IsNullOrEmpty(nome))
            {
                Taskk newTask = new Taskk(nome, date, status);
                taskc.AddTask(newTask); 
                UpdateDataGridView(); 
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (dgv_tasks.CurrentRow != null)
            {
                int taskId = Convert.ToInt32(dgv_tasks.CurrentRow.Cells["Id"].Value);

                Taskk toBeDeleted = taskc.tasks.FirstOrDefault(t => t.Id == taskId);

                if (toBeDeleted != null)
                {
                    taskc.RemoveTask(toBeDeleted);
                    UpdateDataGridView();
                }
                else
                {
                    MessageBox.Show("Task not found");
                }
            }
            else
            {
                MessageBox.Show("No task selected.");
            }
        }

        private void UpdateDataGridView()
        {
            taskc.LoadTasksFromDatabase();
            dgv_tasks.DataSource = null;
            dgv_tasks.DataSource = taskc.tasks;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int index = dgv_tasks.CurrentRow.Index;
            Update update = new Update(taskc, index);

            update.FormClosed += (s, args) => UpdateDataGridView();
            update.Show();
        }
    }
}
