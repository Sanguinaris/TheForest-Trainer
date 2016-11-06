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
        }
    }
}
