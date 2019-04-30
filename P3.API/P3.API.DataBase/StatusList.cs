using Dapper;
using P3.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P3.API.Control
{
    public static class StatusList
    {
        public static IList<Status> GetListStatus()
        {
            try
            {
                return DataBase.cnn.Query<Status>("SELECT * FROM plan_status").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IList<Status> GetStatus(int IdP)
        {
            try
            {
                return DataBase.cnn.Query<Status>($"SELECT * FROM  plan_status  WHERE id = {IdP}").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool AddStatus(Status StatusP)
        {
            try
            {
                DataBase.cnn.Query("INSERT INTO plan_status (name) VALUES (@name)", StatusP);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateStatus(Status StatusP)
        {
            try
            {
                DataBase.cnn.Query("UPDATE plan_status SET name = @name WHERE id = @id", StatusP);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoveStatus(int IdP)
        {
            try
            {
                DataBase.cnn.Query($"DELETE FROM plan_status WHERE id = {IdP}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
