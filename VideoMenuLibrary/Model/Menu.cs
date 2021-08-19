using System.Collections.Generic;
using VideoMenuLibrary.Utility;

namespace VideoMenuLibrary.Model
{
    public abstract class Menu
    {
        #region Private, Protected Variables
        protected int Selection { get; set; }

        #endregion

        #region Public Variables
        public string Name { get; set; }
        public List<string> Options { get; set; }

        #endregion

        #region Constructors
        public Menu()
        {
            Initialize();
        }

        public Menu(string name)
        {
            Initialize();
            SetName(name);
        }
        #endregion

        #region Private, Protected Methods
        protected void Initialize()
        {
            Options = new List<string>();
        }

        #region Overridables
        protected abstract void HandleMenu();

        #endregion

        #endregion

        #region Public Methods

        #region Options CRUD
        public void AddOption(string option)
        {
            if (!Options.Contains(option))
                Options.Add(option);
        }

        public void AddOptions(ICollection<string> options)
        {
            var _options = new List<string>(options);
            for (int i = 0; i < _options.Count; i++)
                AddOption(_options[i]);
        }

        public int GetOption(string option)
        {
            return Options.IndexOf(option);
        }

        public List<string> GetOptions()
        {
            return Options;
        }

        public void RemoveOption(string option)
        {
            for (int i = 0; i < Options.Count; i++)
            {
                if (Options.Contains(option))
                    Options.Remove(option);
            }
        }

        #endregion

        #region Menu Operations
        public void SetName(string name)
        {
            Name = name;
        }

        public int GetSelection()
        {
            return Selection;
        }

        public void SetSelection(string selection)
        {
            Selection = Options.IndexOf(selection);
        }

        public void SetSelection(int selection)
        {
            Selection = selection;
        }

        public void ShowMenu()
        {
            HandleMenu();
        }

        #region Input

        public string GetInputSelection()
        {
            var inputSelection = ConsoleUtility.GetInput();
            SetSelection(inputSelection);
            return inputSelection;
        }

        public int GetInputSelectionAsInt()
        {
            SetSelection(ConsoleUtility.GetInputAsInt());
            return Selection;
        }

        #endregion

        #endregion

        #region Overridables

        #endregion

        #endregion
    }
}
