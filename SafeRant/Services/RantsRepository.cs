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

    public class RantsRepository
    {
        private static SqlConnection GetDb()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["SafeRant"].ConnectionString);
        }

        public List<Rant> GetAll()
        {
            using (var db = GetDb())
            {
                db.Open();
                var result = db.Query<Rant>("SELECT * From dbo.Rants").ToList();
                return result;
            }
        }

        public bool Create(AddRantDTO rant)
        {
            using (var db = GetDb())
            {
                db.Open();

                var numberCreated = db.Execute(@"INSERT INTO [dbo].[Rants]
                                                    ([Title],
                                                    [CategoryId],
                                                    [Target],
                                                    [Body],
                                                    [IsFavorite])
                                                 VALUES
                                                    (@Title,
                                                     @CategoryId,
                                                     @Target,
                                                     @Body,
                                                     @IsFavorite)", rant);
                return numberCreated == 1;

            }
        }

        public bool Update(Rant rant)
        {
            using (var db = GetDb())
            {
                db.Open();

                var updateRant = db.Execute(@"UPDATE [dbo].[Rants]
                                                SET [Title] = @Title,
                                                    [CategoryId] = @CategoryId,
                                                    [Target] = @Target,
                                                    [Body] = @Body,
                                                    [IsFavorite] = @IsFavorite
                                                WHERE Id = @Id", rant);

                return updateRant == 1;
            }
        }

        public bool Delete(int Id)
        {
            using (var db = GetDb())
            {
                db.Open();

                var deleteRant = db.Execute(@"DELETE FROM [dbo].[Rants]
                                                WHERE Id = @Id", new
                {
                    Id
                });

                return deleteRant == 1;
            }
        }

        public Rant GetRant(int Id)
        {
            using (var db = GetDb())
            {
                db.Open();
                var rant = db.QueryFirst<Rant>(@"SELECT * FROM Rants WHERE Id = @Id", new
                {
                    Id
                });

                return rant;
            }
        }

        //public List<EmployeeComputer> GetFavorites(int computerId)
        //{
        //    using (var db = GetDb())
        //    {
        //        db.Open();
        //        return db.Query<EmployeeComputer>("SELECT * FROM Employee_Computers WHERE ComputerId = @computerId", new
        //        {
        //            computerId
        //        }).ToList();
        //    }
        //}

    }
}