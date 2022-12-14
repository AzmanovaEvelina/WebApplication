﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Services.Data
{
    public class SecurityDAO
    {
        //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RusToEngGroupName;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";  //connect to database Artur

        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GroupName;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        internal bool FindByUser(UserModel user)
        {
            bool success = false;
            string querystring = "SELECT * FROM dbo.Groups WHERE groupNameRU =@GroupName ";
            using (SqlConnection connection
                 = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(querystring, connection);
                command.Parameters.Add("@GroupName", System.Data.SqlDbType.NVarChar, 50).Value = user.GroupName;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return success;
            }
        }
        internal string FindByUserGROUP(UserModel user)
        {
            //return user.GroupName;
            string groupENG =" ";
            string querystring = "SELECT * FROM dbo.Groups WHERE groupNameRU =@GroupName ";
            //return querystring;

            using (SqlConnection connection
                 = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(querystring, connection);
                command.Parameters.Add("@GroupName", System.Data.SqlDbType.NVarChar, 50).Value = user.GroupName;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            groupENG = reader.GetString(2);
                        }
                    }
                    else
                    {
                        groupENG = "";
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return groupENG;
                //return user;
            }
        }
    }
}