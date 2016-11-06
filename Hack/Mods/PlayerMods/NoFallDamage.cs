using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPForestTrn.Hack.Managers;
using UnityEngine;

namespace PPForestTrn.Hack.Mods.PlayerMods
{
    class NoFallDamage : Module
    {
        public NoFallDamage() : base("No Fall Dmg", KeyCode.None, Categories.mPlayer, GuiNames.Toggle)
        {
        }

        public override void onEnable()
        {
            EventMgr.Instance.registerEventListener(EventNames.onUpdate, this);
        }

        public override void onDisable()
        {
            EventMgr.Instance.deleteEventListener(EventNames.onUpdate, this);
            TheForest.Utils.LocalPlayer.FpCharacter.allowFallDamage = true;
        }

        public override void onUpdate()
        {
            if (!this.getState()) return;
            TheForest.Utils.LocalPlayer.FpCharacter.allowFallDamage = false;
        }
    }
}
