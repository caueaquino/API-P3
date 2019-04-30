using Dapper;
using P3.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P3.API.Control
{
    public static class PlanHistoryList
    {
        public static IList<PlanHistory> GetListPlanHistory()
        {
            try
            {
                return DataBase.cnn.Query<PlanHistory>("SELECT * FROM plans_history").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
