using System;

namespace Mindbox.GeometryCalculator.Shapes;

/// <summary>Представляет фигуру круга.</summary>
public class Circle : IShape
{
	private readonly double _radius;

	#region .ctor

	/// <summary>
	/// Создаёт экземпляр класса <see cref="Circle"/>.
	/// </summary>
	/// <param name="radius">Радиус круга.</param>
	public Circle(double radius)
	{
		if(radius <= 0)
		{
			throw new ArgumentOutOfRangeException("The radius of a circle cannot be negative or zero.");
		}

		_radius = radius;
	}

	#endregion

	/// <inheritdoc />
	public double CalculateArea()
	{
		return Math.PI * Math.Pow(_radius, 2);
	}
}
