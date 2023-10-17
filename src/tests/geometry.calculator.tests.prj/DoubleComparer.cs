using System;
using System.Collections;

namespace Mindbox.GeometryCalculator.Tests;

internal class DoubleComparer : IComparer
{
	private readonly double _epsilon;

	public DoubleComparer(double epsilon)
	{
		_epsilon = epsilon;
	}

	public int Compare(object x, object y)
	{
		if(x is double xValue && y is double yValue)
		{
			if(Math.Abs(xValue - yValue) < _epsilon)
				return 0;
			if(xValue < yValue)
				return -1;
		}
		return 1;
	}
}

