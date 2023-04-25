using SquareCalculator.Library.Shapes;

namespace SquareCalculator.Tests;

public class CircleTests
{
    [Fact]
    public void AreaCalculateByRadius()
    {
        var circle = new Circle(23);
        var result = circle.CalculateArea();
        
        Assert.Equal(1661.90, Math.Round(result, 2));
        
        Assert.Equal(1661.90, Math.Round(circle.Area, 2));
    }
    
    [Fact]
    public void AreaCalculateByIncorrectRadius()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Circle(-23.5));
        Assert.Equal("Provided values must be greater than zero", ex.Message);
    }
}