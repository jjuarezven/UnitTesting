using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace Tests
{
	[TestFixture]
	public class DemeritPointsCalculatorTests
	{
		DemeritPointsCalculator calculator;

		[SetUp]
		public void SetUp()
		{
			calculator = new DemeritPointsCalculator();
		}

		[Test]
		[TestCase(-1)]
		[TestCase(301)]
		public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowArgumentOutOfRangeException(int speed)
		{
			Assert.That(() => calculator.CalculateDemeritPoints(speed), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(64, 0)]
		[TestCase(65, 0)]
		[TestCase(66, 0)]
		[TestCase(70, 1)]
		[TestCase(80, 3)]
		public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedResult)
		{
			Assert.That(calculator.CalculateDemeritPoints(speed), Is.EqualTo(expectedResult));
		}
	}
}
