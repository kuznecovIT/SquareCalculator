using System;

namespace SquareCalculator.Library.Exceptions
{
    public class AssemblyOfTypeNotFoundException : Exception
    {
        public AssemblyOfTypeNotFoundException()
        {
        }

        public AssemblyOfTypeNotFoundException(string message)
            : base(message)
        {
        }

        public AssemblyOfTypeNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}