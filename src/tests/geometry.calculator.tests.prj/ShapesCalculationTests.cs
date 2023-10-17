using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Mindbox.GeometryCalculator.Shapes;

using NUnit.Framework;

namespace Mindbox.GeometryCalculator.Tests;

/// <summary>
/// Представляет набор тестов расчёта фигур.
/// </summary>
[TestFixture]
public class ShapesCalculationTests
{
	#region Data

	private static IEnumerable TestData
	{
		get
		{
			yield return new TestCaseData(new Circle(5), 78.54)
				.SetDescription("Метод должен вычислить площадь круга");
			yield return new TestCaseData(new Triangle(3, 4, 5), 6)
				.SetDescription("Метод должен вычислить площадь треугольника");
		}
	}

	#endregion

	#region Test methods

	[Test]
	[TestCaseSource(nameof(TestData))]
	public void CalculateArea_ShouldCalculateArea_WhenValidShapeProvided(IShape shape, double expectedArea)
	{
		double actualArea = shape.CalculateArea();
		Assert.AreEqual(expectedArea, actualArea, 0.01);
	}

	// TODO: Можно удалить, оставил чтобы можно было посмотреть как выглядело бы иначе
	//[Test]
	//[Description("Метод должен вычислить площадь круга")]
	//public void CalculateCircleArea_ShouldCalculateCircleArea_WhenValidRadiusProvided()
	//{
	//	Circle circle = new Circle(5);
	//	double expectedArea = 78.54;

	//	Assert.AreEqual(expectedArea, circle.CalculateArea(), 0.01);
	//}

	//[Test]
	//[Description("Метод должен вычислить площадь треугольника")]
	//public void CalculateTriangleArea_ShouldCalculateTriangleArea_WhenValidSidesProvided()
	//{
	//	Triangle triangle = new Triangle(3, 4, 5);
	//	double expectedArea = 6;

	//	Assert.AreEqual(expectedArea, triangle.CalculateArea(), 0.01);
	//}

	[Test]
	[Description("Метод должен определить, является ли треугольник прямоугольным")]
	public void IsRightTriangle_ShouldDetermineIfTriangleIsRight_WhenValidSidesProvided()
	{
		var rightTriangle = new Triangle(3, 4, 5);
		var nonRightTriangle = new Triangle(3, 4, 6);

		Assert.IsTrue(rightTriangle.IsRightTriangle(), "Ожидался прямоугольный треугольник");
		Assert.IsFalse(nonRightTriangle.IsRightTriangle(), "Ожидался не прямоугольный треугольник");
	}

	[Test]
	[Description("Метод должен вычислить площадь фигур без знания их типа в compile-time")]
	public void CalculateAreaWithoutKnowingShapeType_ShouldCalculateAreasOfDifferentShapes()
	{
		IShape circle = new Circle(5);
		IShape triangle = new Triangle(3, 4, 5);

		var shapesList = new List<IShape>() { circle, triangle };
		var areas = shapesList.Select(shape => shape.CalculateArea());

		double[] expectedAreas = { 78.54, 6 };

		CollectionAssert.AreEqual(expectedAreas, areas, new DoubleComparer(0.1d));
	}

	#endregion
}

