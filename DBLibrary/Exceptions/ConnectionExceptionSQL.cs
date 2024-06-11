using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLibrary.Exceptions
{
    public class ConnectionExceptionSQL : Exception 
    {
        public ConnectionExceptionSQL() { }
        public ConnectionExceptionSQL(string message) : base(message) { }
    }
}
