using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace TestNinja.Mocking
{
	public class VideoService
	{
		//public string ReadVideoTitle()
		//{
		//    var str = new FileReader().Read("video.txt");
		//    var video = JsonConvert.DeserializeObject<Video>(str);
		//    if (video == null)
		//        return "Error parsing the video.";
		//    return video.Title;
		//}


		#region Dependency injection by method parameter
		//public string ReadVideoTitle(IFileReader fileReader)
		//{
		//	var str = fileReader.Read("video.txt");
		//	var video = JsonConvert.DeserializeObject<Video>(str);
		//	if (video == null)
		//		return "Error parsing the video.";
		//	return video.Title;
		//} 
		#endregion

		#region Dependency injection by property		
		//public IFileReader FileReader { get; set; }

		//public VideoService()
		//{
		//	FileReader = new FileReader();
		//}

		//public string ReadVideoTitle()
		//{
		//	var str = FileReader.Read("video.txt");
		//	var video = JsonConvert.DeserializeObject<Video>(str);
		//	if (video == null)
		//		return "Error parsing the video.";
		//	return video.Title;
		//} 
		#endregion

		// Dependency injection by constructor
		readonly IFileReader fileReader;
		readonly IVideoRepository videoRepository;

		public VideoService(IFileReader fileReader = null, IVideoRepository videoRepository = null) // = null to avoid breaking existent code (poor man dependency injection)
		{
			this.fileReader = fileReader ?? new FileReader();
			this.videoRepository = videoRepository ?? new VideoRepository();
		}

		public string ReadVideoTitle()
		{
			var str = fileReader.Read("video.txt");
			var video = JsonConvert.DeserializeObject<Video>(str);
			if (video == null)
				return "Error parsing the video.";
			return video.Title;
		}

		public string GetUnprocessedVideosAsCsv()
		{
			var result = string.Empty;
			var videoIds = new List<int>();
			
			var videos = videoRepository.GetUnprocessedVideos();
			if (videos.Any())
			{
				foreach (var v in videos)
					videoIds.Add(v.Id);
				result = string.Join(",",videoIds);
			}
			return result;
		}
	}

	public class Video
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public bool IsProcessed { get; set; }
	}

	public class VideoContext : DbContext
	{
		public DbSet<Video> Videos { get; set; }
	}
}