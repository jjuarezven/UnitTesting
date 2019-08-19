using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
	[TestFixture]
	public class ProductTests
	{
		[Test]
		public void GetPrice_GoldCustomer_Apply30PercentDiscount()
		{
			var product = new Product { ListPrice = 100 };
			var result = product.GetPrice(new Customer { IsGold = true });
			Assert.That(result, Is.EqualTo(70));
		}

		// Mockup solamente recursos externos a la aplicación.  Abusar de Mocks provoca creacion innecesaria de interfaces.
		// Los tests deben ser simples de escribir, de ejecución ráapida.
		[Test]
		public void GetPrice_GoldCustomer_Apply30PercentDiscountMockAbuse()
		{
			var customer = new Mock<ICustomer>();
			customer.Setup(c => c.IsGold).Returns(true);
			var product = new Product { ListPrice = 100 };
			var result = product.GetPrice(customer.Object);
			Assert.That(result, Is.EqualTo(70));
		}
	}
}
