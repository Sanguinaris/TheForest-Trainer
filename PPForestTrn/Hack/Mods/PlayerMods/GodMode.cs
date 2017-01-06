using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using PPForestTrn.Hack.Managers;

namespace PPForestTrn.Hack.Mods.PlayerMods
{
    class GodMode : Module
    {
        public GodMode() : base("God Mode", KeyCode.None, Categories.mPlayer, GuiNames.Toggle)
        {
        }

        public override void onEnable()
        {
            EventMgr.Instance.registerEventListener(EventNames.onUpdate, this);
        }

        public override void onDisable()
        {
            EventMgr.Instance.deleteEventListener(EventNames.onUpdate, this);
        }

        public override void onUpdate()
        {
            if (!this.getState())
                return;
            TheForest.Utils.LocalPlayer.Stats.Health = 1337;
        }
    }
}
