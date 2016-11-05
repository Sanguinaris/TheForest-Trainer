using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPForestTrn.Hack.Mods
{
    class PlayerMods
    {
        #region Variables
        public bool isGodMode = false;

        #endregion

        #region HackFunctions
        private void doGodMode()
        {

        }

        #endregion

        #region StandardFunctions

        public void onUpdate()
        {
            if (isGodMode)
                doGodMode();
        }


        #endregion
    }
}
