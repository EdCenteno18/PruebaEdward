/**==========================================================================
 * System: TS Vacancy
 * Module: Administration Website
 * Author: Edward Centeno
 * Company: @r-Tech SRL Costa Rica
 * Date: Sep, 2018
 *==========================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PG.LST.PSC.TSVACANCY.entities
{
    public class Candidate
    {
        public Candidate(){ }

        public int ID { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int IDstatus { get; set; }
        public DateTime birthday { get; set; }
    

     }
}