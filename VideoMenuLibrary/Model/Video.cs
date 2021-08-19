using System;

namespace VideoMenuLibrary.Model
{
    public class Video
    {
        #region Public Variables
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string StoryLine { get; set; }
        #endregion

        #region Constructors

        public Video()
        {

        }

        public Video(int id, string title, DateTime releaseDate, string storyLine)
        {
            Id = id;
            Title = title;
            ReleaseDate = releaseDate;
            StoryLine = storyLine;
        }

        public Video(string title, string storyLine, DateTime releaseDate)
        {
            Title = title;
            ReleaseDate = releaseDate;
            StoryLine = storyLine;
        }

        #endregion

        #region Public Methods
        public string GetInfo()
        {
            return string.Format("Id: {0}\nTitle: {1}\nRelease date: {2}", Id, Title, ReleaseDate.ToString("dd/MM/yyyy"));
        }
        #endregion
    }
}
