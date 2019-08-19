using NUnit.Framework;
using TestNinja.Fundamentals;

namespace Tests
{
	[TestFixture]
	public class FizzBuzzTests
	{		
		[Test]
		public void GetOutput_InputIsDivisibleBy3And5_ReturnFizzBuzz()
		{
			Assert.That(FizzBuzz.GetOutput(15), Is.EqualTo("FizzBuzz"));
		}

		[Test]
		public void GetOutput_InputIsDivisibleBy3Only_ReturnFizz()
		{
			Assert.That(FizzBuzz.GetOutput(9), Is.EqualTo("Fizz"));
		}

		[Test]
		public void GetOutput_InputIsDivisibleBy5Only_ReturnBuzz()
		{
			Assert.That(FizzBuzz.GetOutput(5), Is.EqualTo("Buzz"));
		}

		[Test]
		public void GetOutput_InputIsNotDivisibleBy3Or5O_ReturnTheSameNumber()
		{
			Assert.That(FizzBuzz.GetOutput(2), Is.EqualTo("2"));
		}
	}
}