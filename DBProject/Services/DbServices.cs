using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DBProject.Models;

namespace DBProject.Services
{
    public class DbServices
    {
        public const string connectionString = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        


        public void AddMovie (Movie movie)
        {
            string ADD_MOVIE_TO_DB = "INSERT INTO [dbProject4].dbo.MOVIE (MovieTitle, Producer, ReleaseDate, RunTime, Budget, Gross) VALUES ('" + movie.Title + "', '" + 
                movie.Producer + "', '" + movie.ReleaseDate + "', '" + movie.RunTime + "', '" + movie.Budget + "', '" + movie.Gross + "')";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(ADD_MOVIE_TO_DB))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }            
        }

        public void AddActor (Actor actor)
        {
            string ADD_ACTOR_TO_DB = "INSERT INTO Actors (Name, Gender, BirthDate) VALUES ('" + actor.Name + "', '" + actor.Gender + "', '" + actor.BirthDate + "')";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = ADD_ACTOR_TO_DB;
                cmd.ExecuteNonQuery();
            }
        }
    }
}