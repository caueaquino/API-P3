using Dapper;
using P3.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P3.API.Control
{
    public static class PlanList
    {
        public static IList<Plan> GetListPlan()
        {
            try
            {
                return DataBase.cnn.Query<Plan>("SELECT * FROM plans").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IList<Plan> GetPlan(int IdP)
        {
            try
            {
                return DataBase.cnn.Query<Plan>($"SELECT * FROM plans WHERE id = {IdP}").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool AddPlan(Plan PlanP)
        {
            try
            {
                DataBase.cnn.Query("INSERT INTO plans (name, id_type, id_user, start_date, end_date, description, cost) VALUES (@name, @id_type, @id_user, @start_date, @end_date, @description, @cost)", PlanP);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdatePlan(Plan PlanP)
        {
            try
            {
                DataBase.cnn.Query("UPDATE plans SET name = @name, id_type = @id_type, id_user = @id_user, start_date = @start_date, end_date = @end_date, description = @description, cost = @cost WHERE id = @id", PlanP);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemovePlan(int IdP)
        {
            try
            {
                DataBase.cnn.Query($"DELETE FROM plans WHERE id = {IdP}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
