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

namespace PG.LST.PSC.TSVACANCY.Models
{
    public class Log
    {
        private static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static void Save(string UserId, string Type, string Message, string Details = "")
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmdPerm = connection.CreateCommand();
                cmdPerm.CommandText = "INSERT INTO [tbl_UserLog] (UserId, LogDate, Type, Message, Details, Origin) " +
                                      "VALUES (@UserId, GETDATE(), @Type, @Message, @Details, 'W') ;";

                cmdPerm.Parameters.AddWithValue("@UserId", UserId);
                cmdPerm.Parameters.AddWithValue("@Type", Type);
                cmdPerm.Parameters.AddWithValue("@Message", Message);
                cmdPerm.Parameters.AddWithValue("@Details", Details);

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
    }
}