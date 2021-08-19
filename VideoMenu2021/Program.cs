using System;
using System.Globalization;
using VideoMenuLibrary;
using VideoMenuLibrary.Model;
using static VideoMenuLibrary.Utility.ConsoleUtility;

namespace VideoMenu20021
{
    class Program
    {
        static VideoMenu VideoMenu;
        static VideoManager VideoManager;

        static void Main(string[] args)
        {
            Initialize();
            GetStarted();
        }

        static void Initialize()
        {
            VideoManager = new VideoManager();
            VideoMenu = new VideoMenu("Video Menu");
            VideoMenu.AddOptions(new string[]
            {
                "Add Video",
                "Get Video",
                "Remove Video",
                "Video List",
            });
        }

        static void GetStarted()
        {
            VideoMenu.ShowMenu();

            while ((VideoMenu.GetSelection()) != VideoMenu.GetOption("Exit"))
            {
                switch (VideoMenu.GetInputSelectionAsInt())
                {
                    case 0:
                        HandleAddVideo();
                        break;

                    case 1:
                        HandleGetVideo();
                        break;

                    case 2:
                        HandleRemoveVideo();
                        break;

                    case 3:
                        HandleListAllVideos();
                        break;
                }

                // Little check for the exit stage.
                if (VideoMenu.GetSelection() != VideoMenu.GetOption("Exit"))
                {
                    // Show the menu after any of the cases have been executed.
                    "".PrintLine();
                    VideoMenu.ShowMenu();
                }
            }

            // Exit.
            "Goodbye, boss.".PrintLine(PrefixType.NARRATOR);
        }

        static void HandleAddVideo()
        {
            "Add Video".MakeHeader(2).PrintLine();

            string title = null;
            string storyLine = null;
            DateTime releaseDate = DateTime.Now;
            var input = "";

            //if (VideoManager.HasTempVideo())
            //{
            //    "A video you tried to add earlier exists boss. You want to edit that? (y/n)".PrintLine(PrefixType.NARRATOR);
            //    input = VideoMenu.GetInputSelection();
            //    switch (input)
            //    {
            //        case "y":
            //            var tempVideo = VideoManager.GetTempVideo();
            //            title = tempVideo.Title;
            //            storyLine = tempVideo.StoryLine;
            //            releaseDate = tempVideo.ReleaseDate;
            //            skipFullSetup = true;
            //            break;
            //    }
            //}

            "Enter its title, please.".PrintLine(PrefixType.VIDEO_TITLE);
            input = VideoMenu.GetInputSelection();

            // Stop adding if the title already exists.
            if (VideoManager.HasVideo(input))
            {
                "That video may already exist in our collection or not at all, boss. Please try again.".PrintLine(PrefixType.NARRATOR);
                return;
            }

            // Assign title.
            title = input;
            $"So the title is: \"{input}\", huh? Okay. Now to its story line.".PrintLine(PrefixType.NARRATOR);

            // Assign story line.
            input = VideoMenu.GetInputSelection();
            storyLine = input;
            $"\"{input}\", \nis the story line? Shit, okay then. Last, its release date.".PrintLine(PrefixType.VIDEO_RELEASE_DATE);
            $"The format is as follows: date/month/year. Press enter if you are lazy, boss.".PrintLine(PrefixType.NARRATOR);

            // Assign release date (parse from the input).
            input = VideoMenu.GetInputSelection();
            if (string.IsNullOrEmpty(input))
            {
                "Boss I thought you were cool, man.".PrintLine(PrefixType.NARRATOR);
            }
            else
            {
                try
                {
                    releaseDate = DateTime.ParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    $"{releaseDate.ToString("dd/MM/yyyy")} is its release date? Boss you are amazing!".PrintLine(PrefixType.NARRATOR);
                }
                catch (FormatException)
                {
                    $"{input} is not a correct date, boss. I'll set it to be now for you.".PrintLine(PrefixType.NARRATOR);
                }
                finally
                {
                    releaseDate = DateTime.Now;
                }
            }

            // And lastly, add that shit.
            bool okay = VideoManager.AddVideo(title, storyLine, releaseDate);
            if (okay) $"Added video: {title}. Good job boss! Another original video to the collection.".PrintLine(PrefixType.NARRATOR);
            else "That video may already exist in our collection or not at all, boss. Please try again.".PrintLine(PrefixType.NARRATOR);
        }

        static void HandleGetVideo()
        {
            "Get Video".MakeHeader(2).PrintLine();
            int id = 0;
            Video desiredVideo = null;
            bool useNumber = false;

            $"Okay, enter the video's id or title for starters.".PrintLine(PrefixType.VIDEO_TITLE);
            var input = VideoMenu.GetInputSelection();
            useNumber = int.TryParse(input, out id);

            // Number.
            $"Gotcha... Let me see if we have that video...".PrintLine(PrefixType.NARRATOR);
            var tempVideo = useNumber ? VideoManager.GetVideo(id) : VideoManager.GetVideo(input);
            if (tempVideo != null)
            {
                "Found video".MakeHeader(2).PrintLine();
                desiredVideo = tempVideo;
                desiredVideo.GetInfo().PrintLine();
                $"Bam! Got 'em! Hah, pun!".PrintLine(PrefixType.NARRATOR);
            }
            else $"Can't find that video, boss. Did you put on your glasses?".PrintLine(PrefixType.NARRATOR);
        }

        static void HandleRemoveVideo()
        {
            "Remove Video".MakeHeader(2).PrintLine();
            int id = 0;
            Video desiredVideo = null;
            bool useNumber = false;

            $"Okay, enter the video's id or title for starters.".PrintLine(PrefixType.VIDEO_TITLE);
            var input = VideoMenu.GetInputSelection();
            useNumber = int.TryParse(input, out id);

            // Number.
            $"Gotcha... Let me see if we have that video...".PrintLine(PrefixType.NARRATOR);
            var tempVideo = useNumber ? VideoManager.GetVideo(id) : VideoManager.GetVideo(input);
            if (tempVideo != null)
            {
                "Found video".MakeHeader(2).PrintLine();
                desiredVideo = tempVideo;
                desiredVideo.GetInfo().PrintLine();
                $"Bam! Got 'em! Hah, pun! Removing it...".PrintLine(PrefixType.NARRATOR);
                if (VideoManager.RemoveVideo(desiredVideo))
                    "Removed the video, boss!".PrintLine(PrefixType.NARRATOR);
                else "Failed to remove the video, boss! Did you put on your glasses?".PrintLine(PrefixType.NARRATOR);
            }
            else $"Can't find that video, boss. Did you put on your glasses?".PrintLine(PrefixType.NARRATOR);
        }

        static void HandleListAllVideos()
        {
            "Video List".MakeHeader(2).PrintLine();
            var videos = VideoManager.GetVideos();

            if (videos.Count > 0)
            {
                $"Found: {videos.Count} video(s).".MakeHeader(4).PrintLine();
                for (int i = 0; i < videos.Count; i++)
                {
                    var video = videos[i];
                    video.GetInfo().PrintLine();
                    "".PrintLine();
                }
            }
            else "No videos found, boss! Please add some.".PrintLine(PrefixType.NARRATOR);
        }
    }
}
