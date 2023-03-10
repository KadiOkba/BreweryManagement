using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreweryManagement.Application.Exceptions
{
    public class NotValidException : Exception
    {
        public NotValidException(string message) : base(message)
        {

        }
        public NotValidException(string message, Exception ex) : base(message, ex)
        {

        }

    }
}