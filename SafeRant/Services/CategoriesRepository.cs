using Dapper;
using SafeRant.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SafeRant.Services
{
    public class CategoriesRepository
    {

        private static SqlConnection GetDb()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["SafeRant"].ConnectionString);
        }

        public List<Category> GetAll()
        {
            using (var db = GetDb())
            {
                db.Open();
                var result = db.Query<Category>("SELECT * From dbo.Categories").ToList();
                return result;
            }
        }
    }
}