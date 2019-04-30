using System;

namespace P3.API.Model
{
    public class User
    {
        public int id { get; }
        public string name { get; set; }
        public DateTime register_date { get; set; }
        public DateTime last_changed_date { get; set; }
        public bool can_create_plan { get; set; }
        public bool removed { get; set; }


        public User(int id, string name, DateTime register_date, DateTime last_changed_date, bool can_create_plan, bool removed)
        {
            this.id = id;
            this.name = name;
            this.register_date = register_date;
            this.last_changed_date = last_changed_date;
            this.can_create_plan = can_create_plan;
            this.removed = removed;
        }
    }
}
