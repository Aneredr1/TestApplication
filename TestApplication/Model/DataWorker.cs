using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestApplication.Model.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TestApplication.Model
{
    public static class DataWorker
    {
        //получение пользователей
        public static List<User> Sel_users()
        {
            using (DataContext db = new DataContext())
            {
                return db.Users.ToList();
            }
        
        }
        //получеине номенклатур
        public static List<Nomenclature> Sel_nomenclature()
        {
            using (DataContext db = new DataContext())
            {
                return db.Nomenclatures.ToList();
            }

        }
        //проверка данных для авторизации
        public static bool Check_authentification(string login, string pass)
        {
            using (DataContext db = new DataContext())
            {
                return db.Users.Any(el => el.Login == login && el.Pass == pass);
            }
        }
        //вызов процедуры iud
        public static string IUD_nomenclature(char flag, int nomenclature_id, string name, decimal price, DateTime fromdate, DateTime todate)
        {
            using (DataContext db = new DataContext())
            {
                try
                {
                    List<SqlParameter> sqlParameters = new List<SqlParameter>
                    {
                        new SqlParameter("@flag", flag),
                        new SqlParameter("@nomenclature_id", nomenclature_id),
                        new SqlParameter("@name", name),
                        new SqlParameter("@price", price),
                        new SqlParameter("@fromdate", fromdate),
                        new SqlParameter("@todate", todate)

                    };
                    int res = db.Database.ExecuteSqlRaw("EXECUTE iud_nomenclature @flag, @nomenclature_id, @name, @price, @fromdate, @todate", sqlParameters.ToArray());
                    if (res == 1)
                    {
                        return "Успех";
                    }
                    else return "Ошибка";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                    throw;
                }
            }
        }
    }
}
