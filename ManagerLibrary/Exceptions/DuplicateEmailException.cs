using System;

namespace ManagerLibrary.Exceptions
{
    public class DuplicateEmailException : Exception
    {
        public DuplicateEmailException() : base("A user with the same email already exists.")
        {
        }

        public DuplicateEmailException(string message) : base(message)
        {
        }

        public DuplicateEmailException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
