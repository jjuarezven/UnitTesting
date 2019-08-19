using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class MathTests
	{
		private Math math;

		[SetUp]
		public void SetUp()
		{
			math = new Math();
		}


		[Test]
		public void Add_WhenCalled_ReturnTheSumOfArguments()
		{
			var result = math.Add(1, 2);
			Assert.That(result, Is.EqualTo(3));
		}

		#region Antes de tests parametrizados
		//[Test]
		//public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
		//{
		//	var result = math.Max(3, 2);
		//	Assert.That(result, Is.EqualTo(3));
		//}

		//[Test]
		//public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
		//{
		//	var result = math.Max(1, 3);
		//	Assert.That(result, Is.EqualTo(3));
		//}

		[Test]
		[Ignore("Para probar el atributo Ignore")]
		public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
		{
			var result = math.Max(3, 3);
			Assert.That(result, Is.EqualTo(3));
		}
		#endregion

		#region Test parametrizados
		[Test]
		[TestCase(2, 1, 2)]
		[TestCase(1, 2, 2)]
		[TestCase(2, 2, 2)]
		public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
		{
			var result = math.Max(a, b);
			Assert.That(result, Is.EqualTo(expectedResult));
		}
		#endregion

		[Test]
		public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
		{
			var result = math.GetOddNumbers(5);
			//Assert.That(result, Is.Not.Empty);

			//Assert.That(result, Does.Contain(1));
			//Assert.That(result, Does.Contain(3));
			//Assert.That(result, Does.Contain(5));

			Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));
		}
	}
}
