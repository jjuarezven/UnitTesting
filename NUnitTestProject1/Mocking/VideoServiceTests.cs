using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TestNinja.Mocking;

namespace NUnitTestProject1.Mocking
{
	[TestFixture]
	public class VideoServiceTests
	{
		VideoService videoService;
		Mock<IFileReader> fileReader;
		Mock<IVideoRepository> videoRepository;

		[SetUp]
		public void Setup()
		{
			fileReader = new Mock<IFileReader>();
			videoRepository = new Mock<IVideoRepository>();
			videoService = new VideoService(fileReader.Object, videoRepository.Object);
		}		

		// Using MOQ
		[Test]
		public void ReadVideoTitle_EmptyFile_ReturnError()
		{			
			fileReader.Setup(fr => fr.Read("video.txt")).Returns("");
			
			
			var result = videoService.ReadVideoTitle();
			Assert.That(result, Does.Contain("error").IgnoreCase);
		}

		[Test]
		public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnsAnEmptyString()
		{
			videoRepository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());
			var result = videoService.GetUnprocessedVideosAsCsv();
			Assert.That(result, Is.EqualTo(string.Empty));
		}

		[Test]
		public void GetUnprocessedVideosAsCsv_SomeVideosAreUnprocessed_ReturnsAStringWithIdOfUnprocessedVideos()
		{
			var videos = new List<Video>
			{
				new Video { Id = 1, Title = "Video1", IsProcessed = false },
				new Video { Id = 2, Title = "Video1", IsProcessed = false },
				new Video { Id = 3, Title = "Video2", IsProcessed = false }
			};
			videoRepository.Setup(r => r.GetUnprocessedVideos()).Returns(videos);
			var result = videoService.GetUnprocessedVideosAsCsv();
			Assert.That(result, Is.EqualTo("1,2,3"));
		}

		#region Using Dependency injection by method parameter
		//[Test]
		//public void ReadVideoTitle_EmptyFile_ReturnError()
		//{
		//	var service = new VideoService();
		//	var result = service.ReadVideoTitle(new FakeFileReader());
		//	Assert.That(result, Does.Contain("error").IgnoreCase);
		//} 
		#endregion

		#region Using Dependency injection by property
		//[Test]
		//public void ReadVideoTitle_EmptyFile_ReturnError()
		//{
		//	var service = new VideoService();
		//	service.FileReader = new FakeFileReader();
		//	var result = service.ReadVideoTitle();
		//	Assert.That(result, Does.Contain("error").IgnoreCase);
		//} 
		#endregion

		#region Using Dependency injection by constructor without MOQ
		//[Test]
		//public void ReadVideoTitle_EmptyFile_ReturnError()
		//{
		//	var service = new VideoService(new FakeFileReader());
		//	var result = service.ReadVideoTitle();
		//	Assert.That(result, Does.Contain("error").IgnoreCase);
		//} 
		#endregion
	}
}
