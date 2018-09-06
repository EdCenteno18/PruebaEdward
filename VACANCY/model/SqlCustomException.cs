/**==========================================================================
 * System: TS Vacancy
 * Module: Administration Website
 * Author: Lucas Porcelli, Edward Centeno
 * Company: @r-Tech SRL Costa Rica
 * Date: Sep, 2018
 *==========================================================================*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PG.LST.PSC.TSVACANCY.Models
{
    public class SqlCustomException : Exception
    {
        public SqlCustomException() 
            : base()
        { }

        public SqlCustomException(string message)
            : base(message)
        { }
        
        public SqlCustomException(String message, Exception innerException) 
            : base(message, innerException)
        { }

        protected SqlCustomException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        { }

    }
}