using Moq;
using NUnit.Framework;
using System.Net;
using TestNinja.Mocking;


namespace TestNinja.UnitTests.Mocking
{
	[TestFixture]
	public class InstallerHelperTests
	{
		Mock<IFileDownloader> fileDownloader;
		private InstallerHelper installerHelper;

		[SetUp]
		public void Setup()
		{
			fileDownloader = new Mock<IFileDownloader>();
			installerHelper = new InstallerHelper(fileDownloader.Object);
		}

		[Test]
		public void DownloadInstaller_DonwloadFails_ReturnFalse()
		{
			fileDownloader.Setup(fd => fd.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();
			var result = installerHelper.DownloadInstaller("customer", "installer");
			Assert.That(result, Is.False);
		}

		[Test]
		public void DownloadInstaller_DonwloadCompletes_ReturnTrue()
		{			
			var result = installerHelper.DownloadInstaller("customer", "installer");
			Assert.That(result, Is.True);
		}
	}
}
