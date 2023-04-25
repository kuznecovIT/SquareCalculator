using System;

namespace SquareCalculator.Library.Exceptions
{
    public class ShapeCreationException : Exception
    {
        public ShapeCreationException()
        {
        }

        public ShapeCreationException(string message)
            : base(message)
        {
        }

        public ShapeCreationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}