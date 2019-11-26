using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication10.Models
{
    public class FakeRepository
    {
        private static List<VideoBox> _repo = new List<VideoBox>
        {
            new VideoBox()
            {
                Video = new VideoItem(),
                Name = "Name 1",
                Author = "Author 1",
                Level = Level.Beginner,
                Course = "Course 1"
            },

            new VideoBox()
            {
                Video = new VideoItem(),
                Name = "Name 2",
                Author = "Author 2",
                Level = Level.Beginner,
                Course = "Course 2"
            },

            new VideoBox()
            {
                Video = new VideoItem(),
                Name = "Name 3",
                Author = "Author 3",
                Level = Level.Intermediate,
                Course = "Course 3"
            },

            new VideoBox()
            {
                Video = new VideoItem(),
                Name = "Name 3",
                Author = "Author 4",
                Level = Level.Intermediate,
                Course = "Course 4"
            }
        };
        //С этим надо что-то сделать :)
        public static IEnumerable<VideoBox> GetAll(Filter filter)
        {
            List<VideoBox> result =_repo;

            if (filter.Level!=0)
            {
                result = result.Where(x => x.Level == filter.Level).ToList();
            }
            if (!string.IsNullOrEmpty( filter.Name))
            {
                result = result.Where(x => x.Name.Equals(filter.Name,StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(filter.Course))
            {
                result = result.Where(x => x.Course.Equals(filter.Course, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return result.AsReadOnly();  
        }

        public static VideoBox GetById(string id)
        {
            return _repo.SingleOrDefault(b => b.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        public static VideoBox Add(VideoBox video)
        {
            video.Id = Guid.NewGuid().ToString();
            _repo.Add(video);
            return video;
        }
    }
    public class VideoBox
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public VideoItem Video { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public Level Level { get; set; } = Level.None;
        public string Course { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
