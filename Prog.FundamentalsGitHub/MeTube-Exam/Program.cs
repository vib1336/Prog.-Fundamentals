using System;
using System.Collections.Generic;
using System.Linq;

namespace MeTube_Exam
{
    class Video
    {
        public string VideoName { get; set; }
        public int VideoViews { get; set; }
        public int VideoLikes { get; set; }
        public Dictionary<string, int> Videos { get; set; }

        public Video()
        {
            Videos = new Dictionary<string, int>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Prog. Fundamentals Exam problem - Dictionaries, Objects & Classes

            var allVideos = new List<Video>();
            var line = Console.ReadLine();

            while (line != "stats time")
            {
                string[] info = line.Split(new[] { '-', ':' }).ToArray();

                if (!line.Contains("like") && !line.Contains("dislike"))
                {
                    string videoName = info[0];
                    int videoViews = int.Parse(info[1]);

                    var existingVideo = allVideos.FirstOrDefault(v => v.VideoName == videoName);

                    if (existingVideo == null)
                    {
                        var video = new Video();
                        video.VideoName = videoName;
                        video.VideoViews = videoViews;
                        video.Videos.Add(videoName, videoViews);
                        allVideos.Add(video);
                    }
                    else
                    {
                        existingVideo.VideoViews += videoViews;
                        existingVideo.Videos[videoName] += videoViews;
                    }
                }
                else
                {
                    string commandToRate = info[0];
                    string videoToRate = info[1];

                    if (commandToRate == "like")
                    {
                        var existingVideo = allVideos.FirstOrDefault(v => v.VideoName == videoToRate);
                        if (existingVideo != null)
                        {
                            existingVideo.VideoLikes++;
                        }
                    }
                    else
                    {
                        var existingVideo = allVideos.FirstOrDefault(v => v.VideoName == videoToRate);
                        if (existingVideo != null)
                        {
                            existingVideo.VideoLikes--;
                        }
                    }
                }

                line = Console.ReadLine();
            }

            var finalCommand = Console.ReadLine();

            if (finalCommand == "by views")
            {
                var result = allVideos.OrderByDescending(v => v.VideoViews).ToList();
                foreach (var video in result)
                {
                    Console.WriteLine($"{video.VideoName} - {video.VideoViews} views - {video.VideoLikes} likes");
                }
            }
            else
            {
                var result = allVideos.OrderByDescending(v => v.VideoLikes).ToList();
                foreach (var video in result)
                {
                    Console.WriteLine($"{video.VideoName} - {video.VideoViews} views - {video.VideoLikes} likes");
                }
            }
        }
    }
}
