/**==========================================================================
 * System: TS Vacancy
 * Module: Entities
 * Author: Lucas Porcelli, Edward Centeno
 * Company: @r-Tech SRL Costa Rica
 * Date: Sep, 2018
 *==========================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PG.LST.PSC.TSVACANCY.entities
{
    public class Vacancy
    {
        public Vacancy(){ }

        private int _ID;
        public int ID
        {
            set {_ID=value;}
            get { return _ID; }
        }

        private string _vacancy;
        public string VacancyTitle
        {
            set { _vacancy = value; }
            get { return _vacancy; }
        }

        private string _department;
        public string Department
        {
            set { _department = value; }
            get { return _department; }
        }

        private string _positionTitle;
        public string PositionTitle
        {
            set { _positionTitle = value; }
            get { return _positionTitle; }
        }

        private string _description;
         public string Description
        {
            set { _description = value; }
            get { return _description; }
        }

         private string _costCenter;
         public string CostCenter
         {
             set { _costCenter = value; }
             get { return _costCenter; }
         }

         private string _functionCandidate;
         public string FunctionCandidate
         {
             set { _functionCandidate = value; }
             get { return _functionCandidate; }
         }

         private string _hiringManager;
         public string HiringManager
         {
             set { _hiringManager = value; }
             get { return _hiringManager; }
         }

         private string _country;
         public string Country
         {
             set { _country = value; }
             get { return _country; }
         }

         private string _levelCandidate;
         public string LevelCandidate
         {
             set { _levelCandidate = value; }
             get { return _levelCandidate; }
         }

         private DateTime _startDate;
         public DateTime StartDate
         {
             set { _startDate = value; }
             get { return _startDate; }
         }

         private string _userCreator;
         public string UserCreator
         {
             set { _userCreator = value; }
             get { return _userCreator; }
         }

         private DateTime _dateCreator;
         public DateTime DateCreator
         {
             set { _dateCreator = value; }
             get { return _dateCreator; }
         }

         private int _IDStatus;
         public int IDStatus
         {
             set { _IDStatus = value; }
             get { return _IDStatus; }
         }









    }
}