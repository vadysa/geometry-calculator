using System;

namespace Mindbox.GeometryCalculator.Shapes;

/// <summary>Представляет фигуру треугольника.</summary>
public class Triangle : IShape
{
	private readonly double _side1;
	private readonly double _side2;
	private readonly double _side3;

	#region .ctor

	/// <summary>
	/// Создаёт экземпляр класса <see cref="Triangle"/>.
	/// </summary>
	/// <param name="side1">Длина первой стороны.</param>
	/// <param name="side2">Длина второй стороны.</param>
	/// <param name="side3">Длина третьей стороны.</param>
	public Triangle(double side1, double side2, double side3)
	{
		if(side1 <= 0 || side2 <= 0 || side3 <= 0)
		{
			throw new ArgumentOutOfRangeException("The sides of a triangle cannot be negative or zero.");
		}

		_side1 = side1;
		_side2 = side2;
		_side3 = side3;
	}

	#endregion

	/// <inheritdoc />
	public double CalculateArea()
	{
		double p = (_side1 + _side2 + _side3) / 2;
		return Math.Sqrt(p * (p - _side1) * (p - _side2) * (p - _side3));
	}

	/// <summary>
	/// Проверяет является ли треугольник прямоугольным.
	/// </summary>
	/// <returns>Является ли треугольник прямоугольный.</returns>
	public bool IsRightTriangle()
	{
		double[] sides = { _side1, _side2, _side3 };
		Array.Sort(sides);
		return Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2);
	}
}
