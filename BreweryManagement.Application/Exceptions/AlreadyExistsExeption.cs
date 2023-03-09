using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagement.Application.Exceptions
{
    public class AlreadyExistsExeption:Exception
    {
        public AlreadyExistsExeption(string message):base(message)
        {

        }
        public AlreadyExistsExeption(string message,Exception innerEx):base(message,innerEx)
        {
                
        }
    }
}
