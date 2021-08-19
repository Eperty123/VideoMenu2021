using System.Linq;
using VideoMenuLibrary.Utility;

namespace VideoMenuLibrary.Model
{
    public class VideoMenu : Menu
    {

        #region Private, Protected Variables

        #endregion

        #region Public Variables

        #endregion

        #region Constructors

        public VideoMenu()
        {
        }

        public VideoMenu(string name) : base(name)
        {
        }

        #endregion

        #region Private, Protected Methods
        protected override void HandleMenu()
        {
            $"Welcome to the {Name}!".MakeHeader(4).PrintLine();

            // Add an exit option for the boring ones.
            AddOption("Exit");

            // Get and show the available options.
            var options = GetOptions().ToList();
            for (int i = 0; i < options.Count; i++)
                $"{i} - {options[i]}".PrintLine();

        }
        #endregion

        #region Public Methods

        #endregion
    }
}
