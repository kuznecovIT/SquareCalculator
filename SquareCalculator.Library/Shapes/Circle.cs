using System;

namespace SquareCalculator.Library.Shapes
{
    /// <summary>
    /// Circle shape ◯
    /// </summary>
    public class Circle : Shape
    {
        public double Radius { get; } // Wanna init, but not available for .net standard lib 

        /// <summary>
        /// Construct circle with provided radius
        /// </summary>
        public Circle(double radius)
        {
            Extensions.CheckValuesOfShapeIsGreaterThanZero(radius);
            Radius = radius;
        }
        
        /// <inheritdoc />
        public override double CalculateArea()
        {
            Area = Math.PI * Radius * Radius;
            return Area;
        }
    }
}