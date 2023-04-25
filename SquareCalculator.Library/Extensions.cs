using System;
using System.Linq;

namespace SquareCalculator.Library
{
    internal static class Extensions
    {
        internal static bool TryCreateInstance(this Type type,
            out object? instance, params object?[]? args)
        {
            try
            {
                instance = Activator.CreateInstance(type, args);
                return instance != null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                instance = null;
                return false;
            }
        }

        internal static void CheckValuesOfShapeIsGreaterThanZero(params double[] values)
        {
            if (values.Any(value => value <= 0))
                throw new ArgumentException("Provided values must be greater than zero");
        }
    }
}