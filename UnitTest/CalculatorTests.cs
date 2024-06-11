using AreaCalc;
using AreaCalc.Models;

namespace UnitTest;

[TestFixture]
public class Tests
{
    private ICalculator _calculator;
    
    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [TestCase(1)]
    [TestCase(3.4)]
    public void CircleArea(double radius)
    {
        var result = _calculator.GetCircleArea(new Circle { Radius = radius });

        Console.WriteLine(result.Value);
        
        Assert.That(result.Result, Is.True, result.Message);
    }

    [TestCase(3, 4, 5)]
    [TestCase(8, 10, 6)]
    [TestCase(5, 8, 9)]
    public void TriangleArea(double a, double b, double c)
    {
        var result = _calculator.GetTriangleArea(new Triangle { FirstSide = a, SecondSide = b, ThirdSide = c });

        Console.WriteLine(result.Message + " " + result.Value);
        
        Assert.That(result.Result, Is.True, result.Message);
    }
}