﻿using System;
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
            bool flag = false;

            string ADD_MOVIE_TO_DB = "INSERT INTO [dbProject4].dbo.Movie (Title, Producer, ReleaseDate, RunTime, Budget, Gross, Rating) VALUES ('" + movie.Title + "', '" + 
                movie.Producer + "', '" + movie.ReleaseDate + "', '" + movie.RunTime + "', '" + movie.Budget + "', '" + movie.Gross + "', '" + movie.Rating + "')";
            string CHECK_IF_PRODUCER_EXISTS = "SELECT Name FROM [dbProject4].dbo.Producer WHERE Name = '" + movie.Producer + "'";
            string ADD_PRODUCER_TO_DB = "INSERT INTO [dbProject4].dbo.Producer (Name) VALUES ('" + movie.Producer + "')";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(ADD_MOVIE_TO_DB))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }

                using (SqlCommand cmd = new SqlCommand(CHECK_IF_PRODUCER_EXISTS))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        flag = true;
                    }
                    cmd.Connection.Close();
                }

                if (!flag)
                {
                    using (SqlCommand cmd = new SqlCommand(ADD_PRODUCER_TO_DB))
                    {
                        cmd.Connection = conn;
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
                }

            }            
        }

        public void AddActor (Actor actor)
        {
            string ADD_ACTOR_TO_DB = "INSERT INTO [dbProject4].dbo.Actors (Name) VALUES ('" + actor.Name + "')";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(ADD_ACTOR_TO_DB))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
            
        }
    }
}