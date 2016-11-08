using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPForestTrn.Hack.Managers;
using UnityEngine;

namespace PPForestTrn.Hack.Mods.WorldMods
{
    class KillAll : Module
    {
        public KillAll() : base("Kill All", KeyCode.K, Categories.mWorld, GuiNames.Button)
        {
        }

        public override void onToggle()
        {
            onButtonPress();
        }

        public override void onButtonPress()
        {
            TheForest.Utils.Scene.MutantControler.activeCannibals.Clear();
            TheForest.Utils.Scene.MutantControler.activeBabies.Clear();
            TheForest.Utils.Scene.MutantControler.activeCaveCannibals.Clear();
            TheForest.Utils.Scene.MutantControler.activeFamilies.Clear();
            TheForest.Utils.Scene.MutantControler.activeInstantSpawnedCannibals.Clear();
            TheForest.Utils.Scene.MutantControler.activeWorldCannibals.Clear();
            TheForest.Utils.Scene.MutantControler.disableAllEnemies = true;
        }
    }
}
