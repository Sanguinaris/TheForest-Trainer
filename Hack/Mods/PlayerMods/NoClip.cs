using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPForestTrn.Hack.Managers;
using UnityEngine;

namespace PPForestTrn.Hack.Mods.PlayerMods
{
    class NoClip : Module
    {
        public NoClip() : base("No Clip Mode", KeyCode.None, Categories.mPlayer, GuiNames.Toggle)
        {
        }
    }
}
