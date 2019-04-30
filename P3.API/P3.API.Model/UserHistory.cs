using System;
using System.Collections.Generic;
using System.Text;

namespace P3.API.Model
{
    public class UserHistory
    {
        public int id { get; }
        public int id_user { get; }
        public bool status { get; }

        public bool create_new_plan { get; }
        public DateTime date { get; }


        public UserHistory(int id, int id_user, bool status, bool create_new_plan, DateTime date)
        {
            this.id = id;
            this.id_user = id_user;
            this.status = status;
            this.create_new_plan = create_new_plan;
            this.date = date;
        }
    }
}
