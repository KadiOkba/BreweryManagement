using System;
using System.Collections.Generic;
using System.Text;

namespace BreweryManagement.Application.Exceptions
{
    public class DeleteFailureException : Exception
    {
        public DeleteFailureException()
        {

        }
        public DeleteFailureException(string message):base(message)
        {

        }

    }
}
