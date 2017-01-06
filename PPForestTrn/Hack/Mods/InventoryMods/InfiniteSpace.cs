using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPForestTrn.Hack.Managers;
using UnityEngine;

namespace PPForestTrn.Hack.Mods.InventoryMods
{
    class InfiniteSpace : Module
    {
        public InfiniteSpace() : base("Infinite Inv Space", KeyCode.None, Categories.mInventory, GuiNames.Button)
        {
        }

        public override void onButtonPress()
        {
            foreach(TheForest.Items.Item item in TheForest.Items.ItemDatabase.Items)
            {
                item._maxAmount = 1337;
            }
        }
    }
}
