using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace NUnitTestProject1.Mocking
{
	[TestFixture]
	public class EmployeeControllerTests
	{
		[Test]
		public void DeleteEmployee_WhenCalled_DeleteTheEmployeeFromDb()
		{
			var employeeStorage = new Mock<IEmployeeStorage>();
			var controller = new EmployeeController(employeeStorage.Object);
			controller.DeleteEmployee(1);
			employeeStorage.Verify(s => s.DeleteEmployee(1));
		}

		[Test]
		public void DeleteEmployee_WhenCalled_ReturnRedirectResult()
		{
			var employeeStorage = new Mock<IEmployeeStorage>();
			var controller = new EmployeeController(employeeStorage.Object);
			var result = controller.DeleteEmployee(1);
			Assert.That(result, Is.TypeOf<RedirectResult>());
		}
	}
}
