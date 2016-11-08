using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPForestTrn.Hack.Managers;
using UnityEngine;

namespace PPForestTrn.Hack.Mods.InventoryMods
{
    class AddToInv : Module
    {
        public AddToInv() : base("Add to Inv", KeyCode.None, Categories.mInventory, GuiNames.ButtonWSlider)
        {
            base.maxSliderValue = 1000;
        }

        public override void onButtonPress()
        {
            foreach (TheForest.Items.Item item in TheForest.Items.ItemDatabase.Items)
            {
                TheForest.Utils.LocalPlayer.Inventory.AddItem(item._id, (int)base.sliderValue);
            }
        }
    }
}
