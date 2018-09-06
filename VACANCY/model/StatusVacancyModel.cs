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
    public class StatusVacancyModel
    {
        private static readonly string ConnectionString =
       ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        public static void Save(Vacancy objVacancy)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
            }
        }


        public static void Update(Vacancy objVacancy)
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

        public static List<Candidate> GetAllCandidate()
        {
            List<Candidate> candidates = new List<Candidate>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
            }
            return candidates;
        }

        public static List<Candidate> GetAllCandidateByStatus(int idStatus)
        {
            List<Candidate> candidates = new List<Candidate>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
            }
            return candidates;
        }
    }
}