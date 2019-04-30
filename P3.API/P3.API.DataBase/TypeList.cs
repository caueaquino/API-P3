using Dapper;
using P3.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P3.API.Control
{
    public static class TypeList
    {
        public static IList<Typee> GetListType()
        {
            try
            {
                return DataBase.cnn.Query<Typee>("SELECT * FROM plan_types").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IList<Typee> GetType(int IdP)
        {
            try
            {
                return DataBase.cnn.Query<Typee>($"SELECT * FROM plan_types WHERE id = {IdP}").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool AddType(Typee TypeP)
        {
            try
            {
                DataBase.cnn.Query("INSERT INTO plan_Types (name) VALUES (@name)", TypeP);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateType(Typee TypeP)
        {
            try
            {
                DataBase.cnn.Query("UPDATE plan_types SET name = @name WHERE id = @id", TypeP);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoveType(int IdP)
        {
            try
            {
                DataBase.cnn.Query($"DELETE FROM plan_types WHERE id = {IdP}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
