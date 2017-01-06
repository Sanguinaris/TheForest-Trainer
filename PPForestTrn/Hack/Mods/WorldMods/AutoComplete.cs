using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPForestTrn.Hack.Managers;
using UnityEngine;

namespace PPForestTrn.Hack.Mods.WorldMods
{
    class AutoCompleteExecuter : TheForest.Buildings.Creation.Craft_Structure
    {
        protected override void CheckNeeded()
        {
            if (AutoComplete.shouldAutoComplete)
                this.Build();
            else
                base.CheckNeeded();
        }
    }

    class AutoComplete : Module
    {
        public AutoComplete() : base("Auto Complete", KeyCode.None, Categories.mWorld, GuiNames.Toggle)
        {
        }

        //Craft Structure : CheckNeeded -> build
        public static bool shouldAutoComplete = false;

        public override void onEnable()
        {
            shouldAutoComplete = true;
            EventMgr.Instance.registerEventListener(EventNames.onUpdate, this);
        }

        public override void onDisable()
        {
            shouldAutoComplete = false;
            EventMgr.Instance.deleteEventListener(EventNames.onUpdate, this);
        }

        public override void onUpdate()
        {
            foreach(KeyValuePair<int,TheForest.Buildings.Creation.BuildMission> entry in TheForest.Buildings.Creation.BuildMission.ActiveMissions)
            {
                entry.Value.AmountNeeded = 0;
            }
        }
    }
}
