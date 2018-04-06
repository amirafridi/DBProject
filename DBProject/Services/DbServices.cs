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
        public const string connectionString = "server=den1.mssql5.gear.host;User ID=dbdproject;password=Ue883DPz9V-!";
        public SqlConnection conn = new SqlConnection(connectionString);


        public void AddMovie (Movie movie)
        {

        }
    }
}