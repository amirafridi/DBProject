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
        public const string connectionString = "Server=DESKTOP-IHEUFHU\\MYSERVER;Database=dbProject4;Trusted_Connection=True;";

        public bool AddMovie(Movie movie)
        {
            bool flag = false;
            bool movieflag = false;

            string CHECK_IF_MOVIE_EXISTS = "SELECT Title FROM [dbProject4].dbo.Movie WHERE Title = '" + movie.Title + "'";
            string ADD_MOVIE_TO_DB = "INSERT INTO [dbProject4].dbo.Movie (Title, Producer, ReleaseDate, RunTime, Budget, Gross, Rating) VALUES ('" + movie.Title + "', '" +
                movie.Producer + "', '" + movie.ReleaseYear + "', '" + movie.RunTime + "', '" + movie.Budget + "', '" + movie.Gross + "', '" + movie.Rating + "')";
            string CHECK_IF_PRODUCER_EXISTS = "SELECT Name FROM [dbProject4].dbo.Producer WHERE Name = '" + movie.Producer + "'";
            string ADD_PRODUCER_TO_DB = "INSERT INTO [dbProject4].dbo.Producer (Name) VALUES ('" + movie.Producer + "')";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(CHECK_IF_MOVIE_EXISTS))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        movieflag = true;
                    }
                    cmd.Connection.Close();
                }
                if (!movieflag)
                {
                    using (SqlCommand cmd = new SqlCommand(ADD_MOVIE_TO_DB))
                    {
                        cmd.Connection = conn;
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Connection.Close();
                    }
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

                return flag; // false if producer doesn't exist

            }
        }

        public void AddActor(Actor actor)
        {
            string CHECK_IF_ACTOR_EXISTS = "SELECT Name FROM [dbProject4].dbo.Actor WHERE Name = '" + actor.Name + "'";
            string ADD_ACTOR_TO_DB = "INSERT INTO [dbProject4].dbo.Actor (Name, Gender, Rating) VALUES ('" + actor.Name + "', '" + actor.Gender + "', '" + actor.Rating + "')";
            bool flag = true;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(CHECK_IF_ACTOR_EXISTS))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        flag = false;
                    }
                    cmd.Connection.Close();
                }
                if (flag)
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
        public void AddProducer(Producer producer)
        {
            string CHECK_IF_PRODUCER_EXISTS = "SELECT Name FROM [dbProject4].dbo.Producer WHERE Name = '" + producer.Name + "'";
            string ADD_PRODUCER_TO_DB = "INSERT INTO [dbProject4].dbo.Producer (Name, Gender, Rating) VALUES ('" + producer.Name + "', '" + producer.Gender + "', '" + producer.Rating + "')";
            bool flag = true;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(CHECK_IF_PRODUCER_EXISTS))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        flag = false;
                    }
                    cmd.Connection.Close();
                }
                if (flag)
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

        public bool AddActorToMovie(ActedIn actedIn)
        {
            bool flag = false;
            string INSERT_INTO_ACTEDIN = "INSERT INTO [dbProject4].dbo.ActedIn (Movie, Actor, CharName, Pay) VALUES ('" + actedIn.Movie + "', '" +
                actedIn.Actor + "', '" + actedIn.CharName + "', '" + actedIn.Pay + "')";
            string CHECK_IF_ACTOR_EXISTS = "SELECT * FROM [dbProject4].dbo.Actor WHERE Name = '" + actedIn.Actor + "'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(INSERT_INTO_ACTEDIN))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }

                using (SqlCommand cmd = new SqlCommand(CHECK_IF_ACTOR_EXISTS))
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
            }

            return flag;
        }

        public bool AddMovieToActor(ActedIn actedIn)
        {
            bool flag = false;
            string INSERT_INTO_ACTEDIN = "INSERT INTO [dbProject4].dbo.ActedIn (Movie, Actor, CharName, Pay) VALUES ('" + actedIn.Movie + "', '" +
                actedIn.Actor + "', '" + actedIn.CharName + "', '" + actedIn.Pay + "')";
            string CHECK_IF_MOVIE_EXISTS = "SELECT * FROM [dbProject4].dbo.Movie WHERE Title = '" + actedIn.Movie + "'";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(INSERT_INTO_ACTEDIN))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }

                using (SqlCommand cmd = new SqlCommand(CHECK_IF_MOVIE_EXISTS))
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
            }

            return flag;
        }

        public Movie FetchMovieDetails(string movieTitle)
        {
            string GET_MOVIE_DETAILS = "SELECT * FROM [dbProject4].dbo.Movie WHERE Title = '" + movieTitle + "'";

            Movie movie = new Movie();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(GET_MOVIE_DETAILS))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    movie.Title = movieTitle;
                    movie.Producer = (string)reader["Producer"];
                    movie.ReleaseYear = (int)reader["ReleaseDate"];
                    movie.RunTime = (int)reader["RunTime"];
                    movie.Budget = (int)reader["Budget"];
                    movie.Gross = (int)reader["Gross"];
                    movie.Rating = (int)reader["Rating"];
                    cmd.Connection.Close();
                }
            }
            return movie;
        }

        public List<ActedIn> FetchActorsForMovie(string movieTitle)
        {
            List<ActedIn> actors = new List<ActedIn>();
            string GET_ACTORS_FOR_MOVIE = "SELECT Actor, CharName, Pay FROM [dbProject4].dbo.ActedIn WHERE Movie = '" + movieTitle + "' ORDER BY Pay DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(GET_ACTORS_FOR_MOVIE))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ActedIn actedIn = new ActedIn
                        {
                            Actor = (string)reader["Actor"],
                            CharName = (string)reader["CharName"],
                            Pay = (int)reader["Pay"]
                        };
                        actors.Add(actedIn);
                    }
                    cmd.Connection.Close();
                }
            }

            return actors;
        }

        public List<Movie> FetchAllMovies(string SortBy = "ReleaseDate")
        {
            string GET_ALL_MOVIES = "SELECT Title, Producer, ReleaseDate, Rating FROM [dbProject4].dbo.Movie ORDER BY " + SortBy;
            List<Movie> movies = new List<Movie>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(GET_ALL_MOVIES))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Movie movie = new Movie
                        {
                            Title = (string)reader["Title"],
                            Producer = (string)reader["Producer"],
                            ReleaseYear = (int)reader["ReleaseDate"],
                            Rating = (int)reader["Rating"]
                        };
                        movies.Add(movie);
                    }

                    cmd.Connection.Close();
                }
            }

            return movies;
        }

        public List<Actor> FetchAllActors(string SortBy = "Name")
        {
            string GET_ALL_ACTORS = "SELECT Name, Gender, Rating FROM [dbProject4].dbo.Actor ORDER BY " + SortBy;
            List<Actor> actors = new List<Actor>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(GET_ALL_ACTORS))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Actor actor = new Actor
                        {
                            Name = (string)reader["Name"],
                            Gender = (string)reader["Gender"],
                            Rating = (int)reader["Rating"]
                        };
                        actors.Add(actor);
                    }

                    cmd.Connection.Close();
                }
            }

            return actors;
        }

        public List<Producer> FetchAllProducers(string SortBy = "Name")
        {
            string GET_ALL_PRODUCERS = "SELECT Name, Gender, Rating FROM [dbProject4].dbo.Producer ORDER BY " + SortBy;
            List<Producer> producers = new List<Producer>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(GET_ALL_PRODUCERS))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Producer producer = new Producer
                        {
                            Name = (string)reader["Name"],
                            Gender = (string)reader["Gender"],
                            Rating = (int)reader["Rating"]
                        };
                        producers.Add(producer);
                    }

                    cmd.Connection.Close();
                }
            }

            return producers;
        }

        public Actor FetchActorDetails(string actorName)
        {
            string GET_ACTOR_DETAILS = "SELECT Gender, Rating FROM [dbProject4].dbo.Actor WHERE Name = '" + actorName + "'";

            Actor actor = new Actor
            {
                Name = actorName
            };

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(GET_ACTOR_DETAILS))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    actor.Gender = (string)reader["Gender"];
                    actor.Rating = (int)reader["Rating"];
                    cmd.Connection.Close();
                }
            }

            return actor;
        }

        public Producer FetchProducerDetails(string producerName)
        {
            string GET_PRODUCER_DETAILS = "SELECT Gender, Rating FROM [dbProject4].dbo.Producer WHERE Name = '" + producerName + "'";

            Producer producer = new Producer
            {
                Name = producerName
            };
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(GET_PRODUCER_DETAILS))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    producer.Gender = (string)reader["Gender"];
                    producer.Rating = (int)reader["Rating"];
                    cmd.Connection.Close();
                }
            }
            return producer;
        }

        public List<ActedIn> FetchMoviesForActor(string actorName)
        {
            string GET_MOVIES_FOR_ACTOR = "SELECT Movie, CharName, Pay FROM [dbProject4].dbo.ActedIn WHERE Actor = '" + actorName + "'";
            List<ActedIn> movies = new List<ActedIn>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(GET_MOVIES_FOR_ACTOR))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ActedIn movie = new ActedIn
                        {
                            Movie = (string)reader["Movie"],
                            CharName = (string)reader["CharName"],
                            Pay = (int)reader["Pay"]
                        };
                        movies.Add(movie);
                    }
                    cmd.Connection.Close();
                }
            }

            return movies;
        }

        public List<Movie> FetchMoviesForProducer(string producerName)
        {
            string GET_MOVIES_FOR_PRODUCER = "SELECT Title, ReleaseDate, Rating, Gross FROM [dbProject4].dbo.Movie WHERE " +
                "Producer = '" + producerName + "' ORDER BY ReleaseDate DESC";
            List<Movie> movies = new List<Movie>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(GET_MOVIES_FOR_PRODUCER))
                {
                    cmd.Connection = conn;
                    cmd.Connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Movie movie = new Movie
                        {
                            Title = (string)reader["Title"],
                            ReleaseYear = (int)reader["ReleaseDate"],
                            Rating = (int)reader["Rating"],
                            Gross = (int)reader["Gross"]
                        };
                        movies.Add(movie);
                    }
                    cmd.Connection.Close();
                }
            }

            return movies;
        }

    }
}