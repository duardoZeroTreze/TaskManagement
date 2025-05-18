using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task_Management.Controller;
using Task_Management.Model;

namespace Task_Management.View
{
    public partial class Update : Form
    {
        TaskController taskc;
        int index;
        public Update(TaskController tc, int index)
        {
            InitializeComponent();
            taskc = tc;
            this.index = index;
            txt_name.Text = taskc.tasks[index].Name;
            dtp_date.Value = DateTime.ParseExact(taskc.tasks[index].Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            cb_status.Text = taskc.tasks[index].Status;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string nome = txt_name.Text;
            string date = dtp_date.Value.ToString("yyyy-MM-dd");
            string status = cb_status.Text;

            if (string.IsNullOrWhiteSpace(status))
            {
                MessageBox.Show("Selecione um status válido");
                return;
            }

            if (!string.IsNullOrEmpty(nome))
            {
                var t = taskc.tasks[index];
                t.Name = nome;
                t.Date = date;
                t.Status = status;

                taskc.UpdateTask(t);
            }

            this.Close();
        }
    }
}
