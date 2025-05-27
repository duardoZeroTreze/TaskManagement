using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task_Management.Model
{
    public class Taskk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public Taskk(int id, string name, DateTime date, string status)
        {
            Id = id;
            Name = name;
            Date = date;
            Status = status;
        }
        public Taskk(string name, DateTime date, string status)
        {
            Name = name;
            Date = date;
            Status = status;
        }
    }
}
