using System;
using System.Collections.Generic;
using System.Linq;

namespace VideoMenuLibrary.Model
{
    public class VideoManager
    {
        #region Private, Protected Variables

        private List<Video> Videos;
        private Video TempVideo;

        #endregion

        #region Constructors

        public VideoManager()
        {
            Initialize();
        }

        #endregion

        #region Public Variables

        #endregion

        #region Private, Private Methods

        private void Initialize()
        {
            Videos = new List<Video>();
        }

        #endregion

        #region Public Methods

        #region Video CRUD

        public bool AddVideo(string title, string storyLine, DateTime releaseDate)
        {
            return AddVideo(new Video(title, storyLine, releaseDate));
        }

        public bool AddVideo(Video video)
        {
            if (video != null && !HasVideo(video) && !HasVideoByTitle(video))
            {
                video.Id = Videos.Count + 1;
                Videos.Add(video);
                TempVideo = null;
                return true;
            }
            TempVideo = video;
            return false;
        }

        public Video GetVideo(Video video)
        {
            return GetVideo(video.Id);
        }

        public Video GetVideo(string title)
        {
            return Videos.Find(x => x.Title.Equals(title));
        }

        public Video GetVideo(int id)
        {
            return Videos.Find(x => x.Id.Equals(id));
        }

        public Video GetTempVideo()
        {
            return TempVideo;
        }

        public bool HasTempVideo()
        {
            return TempVideo != null;
        }

        public bool HasVideo(Video video)
        {
            return HasVideo(video.Id);
        }

        public bool HasVideoByTitle(Video video)
        {
            return HasVideo(video.Title);
        }

        public bool HasVideo(int id)
        {
            return Videos.Where(x => x.Id.Equals(id)).Any();
        }

        public bool HasVideo(string title)
        {
            return Videos.Where(x => x.Title.Equals(title)).Any();
        }

        public bool RemoveVideo(Video video)
        {
            return RemoveVideo(video.Id);
        }

        public bool RemoveVideo(int id)
        {
            if (HasVideo(id))
            {
                Videos.Remove(GetVideo(id));
                return true;
            }
            return false;
        }

        #endregion

        public List<Video> GetVideos()
        {
            return Videos;
        }

        #endregion

    }
}
