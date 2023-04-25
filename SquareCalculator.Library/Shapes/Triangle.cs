using System;
using System.Linq;

namespace SquareCalculator.Library.Shapes
{
    /// <summary>
    /// Triangle shape △
    /// </summary>
    public class Triangle : Shape
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }
        
        private readonly bool _baseAndHeightConstructed;

        /// <summary>
        /// Construct triangle with 3 sides lenght
        /// </summary>
        public Triangle(double a, double b, double c)
        {
            ValidateTriangleSides(a, b, c);
            
            A = a;
            B = b;
            C = c;
        }
        
        /// <summary>
        /// Construct triangle with provide only base and height
        /// </summary>
        /// <param name="base">The bottom line of a triangle</param>
        /// <param name="height">Perpendicular line of a triangle segment drawn from the vertex to the opposite side of the triangle</param>
        public Triangle(double @base, double height)
        {
            Extensions.CheckValuesOfShapeIsGreaterThanZero(@base, height);
            
            B = @base;
            C = height;
            _baseAndHeightConstructed = true;
        }
    
        /// <inheritdoc />
        public override double CalculateArea()
        {
            if (_baseAndHeightConstructed)
            {
                Area = (B * C) / 2; // B - for base C - for height
                return Area;
            }
            
            Area = 0.25 * Math.Sqrt((A + B + C) * (-A + B + C) * (A - B + C) * (A + B - C));
            return Area;
        }

        /// <summary>
        /// Checking if a triangle is a right triangle
        /// </summary>
        public bool IsTriangleRightAngled()
        {
            double accumulator = 0;

            var max = new[]{A, B, C}.Aggregate((a, b) =>
            {
                if (a > b)
                {
                    accumulator += b * b;
                    return a;
                }

                accumulator += a * a;
                return b;
            });

            return Math.Abs(accumulator - max * max) < double.Epsilon;
        }
        
        private static void ValidateTriangleSides(double a, double b, double c)
        {
            Extensions.CheckValuesOfShapeIsGreaterThanZero(a, b, c);
            
            if (a + b <= c || a + c <= b || b + c <= a)
                throw new ArgumentException("The sum of two side lengths has to exceed the length of the third side.");
        }
    }
}