using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPForestTrn.Hack.Managers;
using UnityEngine;

namespace PPForestTrn.Hack.Mods.WorldMods
{
    class InstantTree : Module
    {
        public InstantTree() : base("Instant Chop", KeyCode.None, Categories.mWorld, GuiNames.Toggle)
        {
        }

        //Tree Health : Hit -> explode
        public static bool shouldInstantChop = false;

        public override void onEnable()
        {
            shouldInstantChop = true;
        }

        public override void onDisable()
        {
            shouldInstantChop = false;
        }
    }
}
