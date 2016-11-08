using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPForestTrn.Hack.Managers;
using UnityEngine;

namespace PPForestTrn.Hack.Mods.WorldMods
{
    class CaveLight : Module
    {
        public CaveLight() : base("Cave Lightning", KeyCode.None, Categories.mWorld, GuiNames.Toggle)
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
            if (!this.getState()) return;
            if(TheForest.Utils.Scene.Atmosphere.InACave)
            {
                TheForest.Utils.Scene.Atmosphere.CaveAddLight1 = new Color(1f, 1f, 1f);
                TheForest.Utils.Scene.Atmosphere.CaveAddLight2 = new Color(1f, 1f, 1f);
                TheForest.Utils.Scene.Atmosphere.CaveAddLight1Intensity = 1f;
                TheForest.Utils.Scene.Atmosphere.CaveAddLight2Intensity = 1f;
            }
            else
            {
                TheForest.Utils.Scene.Atmosphere.CaveAddLight1 = Color.black;
                TheForest.Utils.Scene.Atmosphere.CaveAddLight2 = Color.black;
                TheForest.Utils.Scene.Atmosphere.CaveAddLight1Intensity = 0.3f;
                TheForest.Utils.Scene.Atmosphere.CaveAddLight2Intensity = 0.3f;
            }
        }
    }
}
