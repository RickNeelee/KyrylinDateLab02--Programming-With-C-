using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyrylinDateLab02.Exceptions
{
    internal class NotBornException : Exception
    {
        public NotBornException() { }
        public NotBornException(string message) : base(message) { }
        public NotBornException(string message, Exception inner) : base(message, inner) { }

    }
}
