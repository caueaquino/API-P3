using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace P3.API.Control
{
    public static class DataBase
    {
        public static SqlConnection cnn = new SqlConnection("Data Source=localhost; Initial Catalog=desafio_sql; Integrated Security=false; User ID=sa;Password=abc123##");
    }
}
