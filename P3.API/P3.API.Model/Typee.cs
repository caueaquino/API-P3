using System;
using System.Collections.Generic;
using System.Text;

namespace P3.API.Model
{
    public class Typee
    {
        public int id { get; }
        public string name { get; set; }


        public Typee(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
