using System;
using System.Collections.Generic;

namespace Xena.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; set; }
        public ValidationException(List<string> errors) : base(string.Join(";",errors))
        {
            Errors = errors;
        }

        public ValidationException(string error) : base(error)
        {
            Errors = new List<string>() { error };
        }
    }
}