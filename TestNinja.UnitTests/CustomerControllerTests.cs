﻿using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
	[TestFixture]
	public class CustomerControllerTests
	{

		[Test]
		public void GetCustomer_IdIsZero_ShouldReturnNotFound()
		{
			var controller = new CustomerController();
			var result = controller.GetCustomer(0);

			Assert.That(result, Is.TypeOf<NotFound>());
		}

		[Test]
		public void GetCustomer_IdIsNotZero_ShouldReturnOk()
		{
			var controller = new CustomerController();
			var result = controller.GetCustomer(1);

			Assert.That(result, Is.TypeOf<Ok>());
		}
	}
}
