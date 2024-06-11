using AreaCalc.Models;

namespace AreaCalc;

public interface ICalculator
{
    Area GetCircleArea(Circle circle);

    Area GetTriangleArea(Triangle triangle);
}