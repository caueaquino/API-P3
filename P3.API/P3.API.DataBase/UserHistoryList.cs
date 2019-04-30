using Dapper;
using P3.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P3.API.Control
{
    public static class UserHistoryList
    {
        public static IList<UserHistory> GetListUserHistory()
        {
            try
            {
                return DataBase.cnn.Query<UserHistory>("SELECT * FROM users_history").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
