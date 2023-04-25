using System;
using System.Linq;
using System.Reflection;
using SquareCalculator.Library.Exceptions;

namespace SquareCalculator.Library.Shapes
{
    /// <summary>
    /// Base class of any shape
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Area of shape.
        /// Can be calculated by provided method <see cref="CalculateArea"/>
        /// </summary>
        public double Area { get; protected set; } // Wanna init, but not available for .net standard lib
        
        /// <summary>
        /// Method that calculates area of shape and returns result.
        /// </summary>
        public abstract double CalculateArea();

        /// <summary>
        /// Create instance of shape by shapeName to perform calculation in compile-time 
        /// </summary>
        /// <param name="shapeName">ShapeName</param>
        /// <param name="shapeParameters">Array of shape parameters</param>
        /// <exception cref="AssemblyOfTypeNotFoundException"><see cref="Assembly.GetAssembly"/> with shapeName as type - returns null</exception>
        /// <exception cref="NotImplementedException">Type of shape is not implemented or missing in loaded assemblies</exception>
        /// <exception cref="ShapeCreationException"><see cref="Extensions.TryCreateInstance"/> unable to create shape</exception> 
        public static Shape CreateShapeInstanceByNameType(string shapeName, object[] shapeParameters)
        {
            var shapeTypeAssembly = Assembly.GetAssembly(typeof(Shape));
            if (shapeTypeAssembly == null)
                throw new AssemblyOfTypeNotFoundException($"Cannot load type assembly : {typeof(Shape).FullName}");
    
            var shapeClassTypes = shapeTypeAssembly
                .GetTypes()
                .Where(myType => myType is {IsClass: true, IsAbstract: false} 
                                 && myType.IsSubclassOf(typeof(Shape)));

            var concreteShapeType = shapeClassTypes.FirstOrDefault(x => x.Name == shapeName);
            if (concreteShapeType == default)
                throw new NotImplementedException($"Type of {shapeName} not implemented. Or missing loaded assemblies for this type");

            if (!concreteShapeType.TryCreateInstance(out var createdInstance, shapeParameters) && createdInstance is Shape shapeInstance) 
                return shapeInstance;
            
            throw new ShapeCreationException("Unable to create shape instance");
        }
    }
}