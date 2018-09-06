/**==========================================================================
 * System: TS Vacancy
 * Module: Administration Website
 * Author: Edward Centeno
 * Company: @r-Tech SRL Costa Rica
 * Date: Sep, 2018
 *==========================================================================*/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PG.LST.PSC.TSVACANCY.entities;
using PG.LST.PSC.TSVACANCY.Models;

namespace PG.LST.PSC.TSVACANCY.model
{
    public class CandidateModel
    {
        private static readonly string ConnectionString =
        ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        public static void Save(Candidate objCandidate)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmdPerm = connection.CreateCommand();
                cmdPerm.CommandText = "INSERT INTO [dbo].[tbl_Candidates]([ID],[surname],[name],[email],[status],[birthday])" +
                    " VALUES(@surname,@name,@email,@status,@birthday,@date)";

                cmdPerm.Parameters.AddWithValue("@surname", objCandidate.surname);
                cmdPerm.Parameters.AddWithValue("@name", objCandidate.name);
                cmdPerm.Parameters.AddWithValue("@email", objCandidate.email);
                cmdPerm.Parameters.AddWithValue("@status", objCandidate.IDstatus);
                cmdPerm.Parameters.AddWithValue("@birthday", objCandidate.birthday);
                try
                {
                    connection.Open();
                    cmdPerm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new SqlCustomException(ex.Message, ex);
                }
            }
        }


        public static void Update(Candidate objCandidate)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmdPerm = connection.CreateCommand();
                cmdPerm.CommandText =
                "UPDATE [tbl_Candidates] SET [surname]='" + objCandidate.surname + "',[name]='" + objCandidate.name + "',[email]='" +
                objCandidate.email + "',[status]='" + objCandidate.IDstatus + "'," +
                "[birthday]='" + objCandidate.birthday + "'" +
                "WHERE ID='" + objCandidate.ID + "'";

                cmdPerm.Parameters.AddWithValue("@surname", objCandidate.surname);
                cmdPerm.Parameters.AddWithValue("@name", objCandidate.name);
                cmdPerm.Parameters.AddWithValue("@email", objCandidate.email);
                cmdPerm.Parameters.AddWithValue("@status", objCandidate.IDstatus);
                cmdPerm.Parameters.AddWithValue("@birthday", objCandidate.birthday);

                try
                {
                    connection.Open();
                    cmdPerm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new SqlCustomException(ex.Message, ex);
                }

            }
        }

        public static void Delete(int ID)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmdPerm = connection.CreateCommand();
                cmdPerm.CommandText = "DELETE [surname],[name],[email],[status],[birthday] " +
                    "FROM  [tbl_Candidates] WHERE ID='" + ID + "'";
                try
                {
                    connection.Open();
                    cmdPerm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new SqlCustomException(ex.Message, ex);
                }
            }

        }

        public static List<Candidate> GetAllCandidate()
        {
            List<Candidate> candidates = new List<Candidate>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"SELECT [ID],[surname],[name],[email],[status],[birthday]" +
                                   "FROM [dbo].[tbl_Candidates] ";
                try
                {
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Candidate objCandidate = new Candidate();
                        objCandidate.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                        objCandidate.surname = dr.GetString(dr.GetOrdinal("surnmae"));
                        objCandidate.name = dr.GetString(dr.GetOrdinal("name"));
                        objCandidate.email = dr.GetString(dr.GetOrdinal("email"));
                        objCandidate.IDstatus = dr.GetInt32(dr.GetOrdinal("status"));
                        objCandidate.birthday = dr.GetDateTime(dr.GetOrdinal("birthday"));
                        candidates.Add(objCandidate);
                    }
                    dr.Close();

                }
                catch (Exception ex)
                {
                    throw new SqlCustomException(ex.Message, ex);

                }
            }
            return candidates;
        }

        public static List<Candidate> GetAllCandidateByStatus(int idStatus)
        {
            List<Candidate> candidates = new List<Candidate>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"SELECT [ID],[surname],[name],[email],[status],[birthday]" +
                                   "FROM [dbo].[tbl_Candidates]  WHERE ID_Status= '" + idStatus + "'";
                try
                {
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Candidate objCandidate = new Candidate();
                        objCandidate.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                        objCandidate.surname = dr.GetString(dr.GetOrdinal("surnmae"));
                        objCandidate.name = dr.GetString(dr.GetOrdinal("name"));
                        objCandidate.email = dr.GetString(dr.GetOrdinal("email"));
                        objCandidate.IDstatus = dr.GetInt32(dr.GetOrdinal("status"));
                        objCandidate.birthday = dr.GetDateTime(dr.GetOrdinal("birthday"));
                        candidates.Add(objCandidate);
                    }
                    dr.Close();

                }
                catch (Exception ex)
                {
                    throw new SqlCustomException(ex.Message, ex);

                }
            }
            return candidates;
        }

    }
}