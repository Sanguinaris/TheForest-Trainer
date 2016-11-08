using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPForestTrn.Hack.Managers;
using UnityEngine;

namespace PPForestTrn.Hack.Mods.WorldMods
{
    class CutMuffukinTrees : Module
    {
        public CutMuffukinTrees() : base("Cut Trees", KeyCode.None, Categories.mWorld, GuiNames.ButtonWSlider)
        {
            base.maxSliderValue = 200f;
        }

        public override void onButtonPress()
        {
            foreach (RaycastHit hit in Physics.SphereCastAll(TheForest.Utils.LocalPlayer.Transform.position, base.sliderValue, new Vector3(1f, 0f, 0f)))
            {
                if (hit.collider.GetComponent<TreeHealth>() != null)
                {
                    hit.collider.gameObject.SendMessage("Explosion", 100f);
                }
            }
        }
    }
}
