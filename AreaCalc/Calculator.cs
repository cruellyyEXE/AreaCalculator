using AreaCalc.Models;
using static System.Double;

namespace AreaCalc;

public class Calculator : ICalculator
{
    public Area GetCircleArea(Circle circle)
    {
        if (circle.Radius <= 0)
            return new Area { Result = false, Message = "Radius cannot be less than or equal to zero." };

        var area = circle.Radius * Math.Pow(Math.PI, 2);

        return new Area { Result = true, Message = "Success.", Value = area };
    }

    public Area GetTriangleArea(Triangle triangle)
    {
        if (triangle.FirstSide <= 0 || triangle.SecondSide <= 0 || triangle.ThirdSide <= 0)
            return new Area{ Result = false, Message = "Side cannot be less than or equal to zero."};
        
        if ((triangle.FirstSide + triangle.SecondSide < triangle.ThirdSide)
            || (triangle.SecondSide + triangle.ThirdSide < triangle.FirstSide)
            || (triangle.FirstSide + triangle.ThirdSide < triangle.SecondSide))
            return new Area{ Result = false, Message = "This triangle is not (can not) exists."};

        var semiPerimeter = (triangle.FirstSide + triangle.SecondSide + triangle.ThirdSide) / 2;

        var area = Math.Sqrt(semiPerimeter * (semiPerimeter - triangle.FirstSide) *
                             (semiPerimeter - triangle.SecondSide) * (semiPerimeter - triangle.ThirdSide));

        var response = new Area
        {
            Result = true, 
            Message = "Success. Triangle is not right.",
            Value = area
        };

        var sides = new double[3] { triangle.FirstSide, triangle.SecondSide, triangle.ThirdSide }.OrderBy(x => x).ToList();

        if (Math.Abs(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2)) <= 0)
            response.Message = "Success. Triangle is right.";
        
        return response;
    }
}