using System.Net;

namespace TestNinja.Mocking
{
	public class InstallerHelper
	{
		private readonly string _setupDestinationFile;
		readonly IFileDownloader fileDownloader;

		public InstallerHelper(IFileDownloader fileDownloader = null)
		{
			this.fileDownloader = fileDownloader ?? new FileDownloader();
		}

		public bool DownloadInstaller(string customerName, string installerName)
		{
			
			try
			{
				fileDownloader.DownloadFile(
					string.Format("http://example.com/{0}/{1}",
						customerName,
						installerName),
					_setupDestinationFile);

				return true;
			}
			catch (WebException)
			{
				return false; 
			}
		}
	}
}