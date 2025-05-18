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
        public string Date { get; set; }
        public string Status { get; set; }
        public Taskk(int id, string name, string date, string status)
        {
            Id = id;
            Name = name;
            Date = date;
            Status = status;
        }
        public Taskk(string name, string date, string status)
        {
            Name = name;
            Date = date;
            Status = status;
        }
    }
}
