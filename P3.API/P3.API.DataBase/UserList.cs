using Dapper;
using P3.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P3.API.Control
{
    public static class UserList
    {
        public static IList<User> GetListUser()
        {
            try
            {
                return DataBase.cnn.Query<User>("SELECT * FROM users").ToList();
            }
            catch(Exception)
            {
                return null;
            }
        }

        public static IList<User> GetUser(int IdP)
        {
            try
            {
                return DataBase.cnn.Query<User>($"SELECT * FROM users WHERE id = {IdP}").ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool AddUser(User UserP)
        {
            try
            {
                DataBase.cnn.Query("INSERT INTO users (name, can_create_plan) VALUES (@name, @can_create_plan)", UserP);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateUser(User UserP)
        {
            try
            {
                DataBase.cnn.Query("UPDATE users SET name = @name, can_create_plan = @can_create_plan, removed = @removed WHERE id = @id", UserP);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool RemoveUser(int IdP)
        {
            try
            {
                DataBase.cnn.Query($"UPDATE users SET removed = 1 WHERE id = {IdP}");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
