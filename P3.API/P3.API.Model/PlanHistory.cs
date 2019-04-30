using System;
using System.Collections.Generic;
using System.Text;

namespace P3.API.Model
{
    public class PlanHistory
    {
        public int id { get; }
        public int id_plan { get; }
        public int id_plan_status { get; }
        public DateTime date { get; }


        public PlanHistory(int id, int id_plan, int id_plan_status, DateTime date)
        {
            this.id = id;
            this.id_plan = id_plan;
            this.id_plan_status = id_plan_status;
            this.date = date;
        }
    }
}
