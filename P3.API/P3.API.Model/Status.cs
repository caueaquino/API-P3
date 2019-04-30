using System;
using System.Collections.Generic;
using System.Text;

namespace P3.API.Model
{
    public class Status
    {
        public int id { get; }
        public string name { get; set; }


        public Status(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
