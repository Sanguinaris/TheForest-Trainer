using PPForestTrn.Hack.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPForestTrn.Hack.Mods.PlayerMods
{
    class HighJump : Module
    {
        public HighJump() : base("High Jump", UnityEngine.KeyCode.None, Categories.mPlayer, GuiNames.Toggle)
        {
            base.maxSliderValue = 100;
        }

        float jumpHeight;
        public override void onEnable()
        {
            EventMgr.Instance.registerEventListener(EventNames.onUpdate, this);
            jumpHeight = TheForest.Utils.LocalPlayer.FpCharacter.jumpHeight;
        }

        public override void onDisable()
        {
            EventMgr.Instance.deleteEventListener(EventNames.onUpdate, this);
            TheForest.Utils.LocalPlayer.FpCharacter.jumpHeight = jumpHeight;
        }

        public override void onUpdate()
        {
            if (!this.getState()) return;
            TheForest.Utils.LocalPlayer.FpCharacter.jumpHeight = jumpHeight * 3;
        }
    }
}
