using SquareCalculator.Library.Shapes;

namespace SquareCalculator.Tests;

public class TriangleTests
{
    [Fact]
    public void AreaCalculateByThreeSides()
    {
        var triangle = new Triangle(2, 2, 3);
        var result = triangle.CalculateArea();
        
        Assert.Equal(1.9843, Math.Round(result, 4));
        
        Assert.Equal(1.9843, Math.Round(triangle.Area, 4));
    }
    
    [Fact]
    public void AreaCalculateByIncorrectThreeSides()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 3));
        Assert.Equal("The sum of two side lengths has to exceed the length of the third side.", ex.Message);
    }
    
    [Fact]
    public void AreaCalculatedByBaseAndHeight()
    {
        var triangle = new Triangle(2.5 ,3.6);
        var result = triangle.CalculateArea();
        
        Assert.Equal(4.5, Math.Round(result, 4));
        
        Assert.Equal(4.5, Math.Round(triangle.Area, 4));
    }
    
    [Fact]
    public void TriangleRightAngled()
    {
        var triangle = new Triangle(3, 4, 5);
        Assert.True(triangle.IsTriangleRightAngled());
    }

    [Fact]
    public void TriangleCreatedByShapeNameAndParameters()
    {
        var triangleSides = new object[] {5.44, 2.3, 4};
        var sidesTriangle = Shape.CreateShapeInstanceByNameType(nameof(Triangle), triangleSides);

        Assert.IsType<Triangle>(sidesTriangle);

        var result = sidesTriangle.CalculateArea();
        
        Assert.Equal(4.1050, Math.Round(result, 4));

        var triangleBaseAndHeight = new object[] {3, 6};
        var baseHeightTriangle = Shape.CreateShapeInstanceByNameType(nameof(Triangle), triangleBaseAndHeight);
        
        var result2 = baseHeightTriangle.CalculateArea();
        
        Assert.Equal(9, result2);
    }
}