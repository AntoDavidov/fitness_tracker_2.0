using System;

namespace ManagerLibrary.Exceptions
{
    public class DuplicateUsernameException : Exception
    {
        public DuplicateUsernameException() : base("A user with the same username already exists.")
        {
        }

        public DuplicateUsernameException(string message) : base(message)
        {
        }

        public DuplicateUsernameException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
