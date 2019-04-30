using System;
using System.Collections.Generic;
using System.Text;

namespace P3.API.Model
{
    public class Plan
    {
        public int id { get; }
        public string name { get; set; }
        public int id_type { get; set; }
        public int id_user { get; set; }
        public int id_status { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string description { get; set; }
        public decimal cost { get; set; }


        public Plan(int id, string name, int id_type, int id_user, int id_status, DateTime start_date, DateTime end_date, string description, decimal cost)
        {
            this.id = id;
            this.name = name;
            this.id_type = id_type;
            this.id_user = id_user;
            this.id_status = id_status;
            this.start_date = start_date;
            this.end_date = end_date;
            this.description = description;
            this.cost = cost;
        }
    }
}
