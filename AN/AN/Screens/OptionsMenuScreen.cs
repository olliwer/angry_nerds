#region File Description
#endregion

#region Using Statements
using Microsoft.Xna.Framework;
#endregion

namespace GameStateManagement
{

    class OptionsMenuScreen : MenuScreen
    {


        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public OptionsMenuScreen()
            : base("Drag Tux using mouse to shoot him and free the birds! GO!")
        {
            MenuEntry exitMenuEntry = new MenuEntry("Exit Options");
            exitMenuEntry.Selected += exitOptions;

            MenuEntries.Add(exitMenuEntry);
        }

        void exitOptions(object sender, PlayerIndexEventArgs e)
        {
            ScreenManager.AddScreen(new MainMenuScreen(), e.PlayerIndex);
        }


        #endregion

        #region Handle Input


        #endregion
    }
}


