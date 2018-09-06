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

namespace PG.LST.PSC.TSVACANCY.model
{
    public class UserLogModel
    {
        private static readonly string ConnectionString =
       ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        public static void Save(UserLog objUserLog)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
            }
        }


        public static void Update(UserLog objUserLog)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {


            }
        }

        public static void Delete(int ID)
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
            }

        }

        public static List<UserLog> GetAllUserLog()
        {
            List<UserLog> userlogs = new List<UserLog>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
            }
            return userlogs;
        }

        public static List<UserLog> GetAllCandidateByStatus(int idStatus)
        {
            List<UserLog> userlogs = new List<UserLog>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
            }
            return userlogs;
        }
    }
}