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

            var task = taskc.tasks[index];

            txt_name.Text = task.Name;
            dtp_date.Value = task.Date;
            cb_status.SelectedItem = task.Status;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string nome = txt_name.Text;
            DateTime date = dtp_date.Value;
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
