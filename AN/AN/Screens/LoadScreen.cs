using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameStateManagement
{
    class LoadScreen : MenuScreen
    {

        #region Fields

        MenuEntry LoadMenuEntry;


        #endregion


        #region initalization

        public LoadScreen(): base("Load")
        {
            MenuEntry LoadMenuEntry = new MenuEntry("Load Game");
            MenuEntry back = new MenuEntry("Back");

            //set event handlers
            back.Selected += OnCancel;


            //add entries to menu
            MenuEntries.Add(LoadMenuEntry);
            MenuEntries.Add(back);
        
        }

        #endregion


    }
}
