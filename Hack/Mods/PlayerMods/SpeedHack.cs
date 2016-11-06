using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPForestTrn.Hack.Managers;
using UnityEngine;

namespace PPForestTrn.Hack.Mods.PlayerMods
{
    class SpeedHack : Module
    {
        public SpeedHack() : base("SpeedHack", KeyCode.None, Categories.mPlayer, GuiNames.Toggle)
        {
        }

        float oldWalkSpeed = 1, oldRunSpeed = 1, oldSwimSpeed = 1;

        public override void onEnable()
        {
            oldWalkSpeed = TheForest.Utils.LocalPlayer.FpCharacter.walkSpeed;
            oldRunSpeed = TheForest.Utils.LocalPlayer.FpCharacter.runSpeed;
            //oldStrafeSpeed = TheForest.Utils.LocalPlayer.FpCharacter.strafeSpeed;
            oldSwimSpeed = TheForest.Utils.LocalPlayer.FpCharacter.swimmingSpeed;
            EventMgr.Instance.registerEventListener(EventNames.onUpdate, this);
        }

        public override void onDisable()
        {
            EventMgr.Instance.deleteEventListener(EventNames.onUpdate, this);
            TheForest.Utils.LocalPlayer.FpCharacter.walkSpeed = oldWalkSpeed;
            TheForest.Utils.LocalPlayer.FpCharacter.runSpeed = oldRunSpeed;
           // TheForest.Utils.LocalPlayer.FpCharacter.strafeSpeed = oldStrafeSpeed;
            TheForest.Utils.LocalPlayer.FpCharacter.swimmingSpeed = oldSwimSpeed;
        }

        public override void onUpdate()
        {
            if (!this.getState()) return;
            TheForest.Utils.LocalPlayer.FpCharacter.walkSpeed = oldWalkSpeed * 3;
            TheForest.Utils.LocalPlayer.FpCharacter.runSpeed = oldRunSpeed * 3;
            //TheForest.Utils.LocalPlayer.FpCharacter.strafeSpeed = oldStrafeSpeed * 3;
            TheForest.Utils.LocalPlayer.FpCharacter.swimmingSpeed = oldSwimSpeed * 5;
        }
    }
}
