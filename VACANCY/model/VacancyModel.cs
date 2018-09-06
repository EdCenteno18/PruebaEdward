/**==========================================================================
 * System: TS Vacancy
 * Module: Administration Website
 * Author: Lucas Porcelli, Edward Centeno
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


namespace PG.LST.PSC.TSVACANCY.Models
{
    public class VacancyModel
    {
        private static readonly string ConnectionString =
        ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        

        public static void Save(Vacancy objVacancy)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmdPerm = connection.CreateCommand();
                cmdPerm.CommandText = "INSERT INTO [tbl_Vacancies] ([vacancy],[department],[positionTitle],[description],[costCenter],"+
                    "[functionCandidate],[hiringManager],[country],[levelCandidate],[startDate],[userCreator],[dateCreator],[ID_Status]) " +
                    "VALUES (@vacancy,@department,@positionTitle,@description,@costCenter,@functionCandidate,@hiringManager,@country,@levelCandidate,"+
                    "@startDate,@userCreator,@dateCreator,@ID_Status) ;";

                cmdPerm.Parameters.AddWithValue("@vacancy", objVacancy.VacancyTitle);
                cmdPerm.Parameters.AddWithValue("@department", objVacancy.Department);
                cmdPerm.Parameters.AddWithValue("@positionTitle", objVacancy.PositionTitle);
                cmdPerm.Parameters.AddWithValue("@description", objVacancy.Description);
                cmdPerm.Parameters.AddWithValue("@costCenter", objVacancy.CostCenter);
                cmdPerm.Parameters.AddWithValue("@functionCandidate", objVacancy.FunctionCandidate);
                cmdPerm.Parameters.AddWithValue("@hiringManager", objVacancy.HiringManager);
                cmdPerm.Parameters.AddWithValue("@country", objVacancy.Country);
                cmdPerm.Parameters.AddWithValue("@levelCandidate", objVacancy.LevelCandidate);
                cmdPerm.Parameters.AddWithValue("@startDate", objVacancy.StartDate);
                cmdPerm.Parameters.AddWithValue("@userCreator", objVacancy.UserCreator);
                cmdPerm.Parameters.AddWithValue("@ID_Status", objVacancy.IDStatus);

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

        public static void Update(Vacancy objVacancy)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmdPerm = connection.CreateCommand();
                    cmdPerm.CommandText =
                    "UPDATE [tbl_Vacancies] SET [vacancy]='" + objVacancy.VacancyTitle + "',[department]='" + objVacancy.Department + "',[positionTitle]='" + 
                    objVacancy.PositionTitle + "',[description]='" + objVacancy.Description + "'," +
                    "[costCenter]='" + objVacancy.CostCenter + "',[functionCandidate]='" + objVacancy.FunctionCandidate + 
                    "',[hiringManager]='" + objVacancy.HiringManager + "',[country]='" + objVacancy.Country + "',[levelCandidate]='" 
                    + objVacancy.LevelCandidate + "',[startDate]='" + objVacancy.StartDate + "',[userCreator]='" + objVacancy.UserCreator + 
                    "',[dateCreator]='" + objVacancy.DateCreator + "',[ID_Status]='" + objVacancy.IDStatus + "'" +
                    "WHERE ID='" + objVacancy.ID + "'";

                cmdPerm.Parameters.AddWithValue("@vacancy", objVacancy.VacancyTitle);
                cmdPerm.Parameters.AddWithValue("@department", objVacancy.Department);
                cmdPerm.Parameters.AddWithValue("@positionTitle", objVacancy.PositionTitle);
                cmdPerm.Parameters.AddWithValue("@description", objVacancy.Description);
                cmdPerm.Parameters.AddWithValue("@costCenter", objVacancy.CostCenter);
                cmdPerm.Parameters.AddWithValue("@functionCandidate", objVacancy.FunctionCandidate);
                cmdPerm.Parameters.AddWithValue("@hiringManager", objVacancy.HiringManager);
                cmdPerm.Parameters.AddWithValue("@country", objVacancy.Country);
                cmdPerm.Parameters.AddWithValue("@levelCandidate", objVacancy.LevelCandidate);
                cmdPerm.Parameters.AddWithValue("@startDate", objVacancy.StartDate);
                cmdPerm.Parameters.AddWithValue("@userCreator", objVacancy.UserCreator);
                cmdPerm.Parameters.AddWithValue("@ID_Status", objVacancy.IDStatus);

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
                cmdPerm.CommandText = "DELETE [vacancy],[department],[positionTitle],[description],[costCenter],[functionCandidate],[hiringManager],"+
                    "[country],[levelCandidate],[startDate],[userCreator],[dateCreator],[ID_Status]" +
                    "FROM  [tbl_Vacancies] WHERE ID='" + ID + "'";
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

        public static List<Vacancy> GetAllVacancy()
        {
            List<Vacancy> vacancies = new List<Vacancy>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"SELECT [ID],[vacancy],[department],[positionTitle],[description],[costCenter],[functionCandidate],"+
                                   "[hiringManager],[country],[levelCandidate],[startDate],[userCreator],[dateCreator],[ID_Status]" +
                                   "FROM [dbo].[tbl_Vacancies] ";
                try
                {
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Vacancy objVacancy = new Vacancy();
                        objVacancy.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                        objVacancy.VacancyTitle = dr.GetString(dr.GetOrdinal("vacancy"));
                        objVacancy.Department = dr.GetString(dr.GetOrdinal("department"));
                        objVacancy.PositionTitle = dr.GetString(dr.GetOrdinal("positionTitle"));
                        objVacancy.Description = dr.GetString(dr.GetOrdinal("description"));
                        objVacancy.CostCenter = dr.GetString(dr.GetOrdinal("costCenter"));
                        objVacancy.FunctionCandidate = dr.GetString(dr.GetOrdinal("functionCandidate"));
                        objVacancy.HiringManager = dr.GetString(dr.GetOrdinal("hiringManager"));
                        objVacancy.Country = dr.GetString(dr.GetOrdinal("country"));
                        objVacancy.LevelCandidate = dr.GetString(dr.GetOrdinal("levelCandidate"));
                        objVacancy.StartDate = dr.GetDateTime(dr.GetOrdinal("startDate"));
                        objVacancy.UserCreator = dr.GetString(dr.GetOrdinal("userCreator"));
                        objVacancy.DateCreator = dr.GetDateTime(dr.GetOrdinal("dateCreator"));
                        objVacancy.IDStatus = dr.GetInt32(dr.GetOrdinal("ID_Status"));

                        vacancies.Add(objVacancy);
                    }
                    dr.Close();

                }
                catch (Exception ex)
                {
                    throw new SqlCustomException(ex.Message, ex);
                }
            }
            return vacancies;
        }

        public static List<Vacancy> GetAllVacancyByStatus(int idStatus)
        {
            List<Vacancy> vacancies = new List<Vacancy>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"SELECT [ID],[vacancy],[department],[positionTitle],[description],[costCenter],[functionCandidate],"+
                                  "[hiringManager],[country],[levelCandidate],[startDate],[userCreator],[dateCreator],[ID_Status]" +
                                  "FROM [dbo].[tbl_Vacancies] WHERE ID_Status= '" + idStatus + "'";
                try
                {
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Vacancy objVacancy = new Vacancy();
                        objVacancy.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                        objVacancy.VacancyTitle = dr.GetString(dr.GetOrdinal("vacancy"));
                        objVacancy.Department = dr.GetString(dr.GetOrdinal("department"));
                        objVacancy.PositionTitle = dr.GetString(dr.GetOrdinal("positionTitle"));
                        objVacancy.Description = dr.GetString(dr.GetOrdinal("description"));
                        objVacancy.CostCenter = dr.GetString(dr.GetOrdinal("costCenter"));
                        objVacancy.FunctionCandidate = dr.GetString(dr.GetOrdinal("functionCandidate"));
                        objVacancy.HiringManager = dr.GetString(dr.GetOrdinal("hiringManager"));
                        objVacancy.Country = dr.GetString(dr.GetOrdinal("country"));
                        objVacancy.LevelCandidate = dr.GetString(dr.GetOrdinal("levelCandidate"));
                        objVacancy.StartDate = dr.GetDateTime(dr.GetOrdinal("startDate"));
                        objVacancy.UserCreator = dr.GetString(dr.GetOrdinal("userCreator"));
                        objVacancy.DateCreator = dr.GetDateTime(dr.GetOrdinal("dateCreator"));
                        objVacancy.IDStatus = dr.GetInt32(dr.GetOrdinal("ID_Status"));

                        vacancies.Add(objVacancy);
                    }
                    dr.Close();

                }
                catch (Exception ex)
                {
                    throw new SqlCustomException(ex.Message, ex);
                }
            }
            return vacancies;
        }

        public static List<Vacancy> GetAllVacancyByUserName(string userName)
        {
            List<Vacancy> vacancies = new List<Vacancy>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"SELECT [ID],[vacancy],[department],[positionTitle],[description],[costCenter],[functionCandidate],"+
                                  "[hiringManager],[country],[levelCandidate],[startDate],[userCreator],[dateCreator],[ID_Status]" +
                                  "FROM [dbo].[tbl_Vacancies] WHERE userCreator= '" + userName + "'" ;
                try
                {
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Vacancy objVacancy = new Vacancy();
                        objVacancy.ID = dr.GetInt32(dr.GetOrdinal("ID"));
                        objVacancy.VacancyTitle = dr.GetString(dr.GetOrdinal("vacancy"));
                        objVacancy.Department = dr.GetString(dr.GetOrdinal("department"));
                        objVacancy.PositionTitle = dr.GetString(dr.GetOrdinal("positionTitle"));
                        objVacancy.Description = dr.GetString(dr.GetOrdinal("description"));
                        objVacancy.CostCenter = dr.GetString(dr.GetOrdinal("costCenter"));
                        objVacancy.FunctionCandidate = dr.GetString(dr.GetOrdinal("functionCandidate"));
                        objVacancy.HiringManager = dr.GetString(dr.GetOrdinal("hiringManager"));
                        objVacancy.Country = dr.GetString(dr.GetOrdinal("country"));
                        objVacancy.LevelCandidate = dr.GetString(dr.GetOrdinal("levelCandidate"));
                        objVacancy.StartDate = dr.GetDateTime(dr.GetOrdinal("startDate"));
                        objVacancy.UserCreator = dr.GetString(dr.GetOrdinal("userCreator"));
                        objVacancy.DateCreator = dr.GetDateTime(dr.GetOrdinal("dateCreator"));
                        objVacancy.IDStatus = dr.GetInt32(dr.GetOrdinal("ID_Status"));

                        vacancies.Add(objVacancy);
                    }
                    dr.Close();

                }
                catch (Exception ex)
                {
                    throw new SqlCustomException(ex.Message, ex);
                }
            }
            return vacancies;
        }
    }
}