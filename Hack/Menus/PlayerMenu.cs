using PPForestTrn.Hack.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PPForestTrn.Hack.Menus
{
    class PlayerMenu : Menu
    {
        PlayerMods mods = new PlayerMods();
        public PlayerMenu() : base("Player Menu", KeyCode.F1)
        {}

        public override void drawGui()
        {
            resetDrawMath();
            GUI.Box(new Rect(curX - 10, 0, normWidth + 10, Screen.height), base.getMenuName());
            GUI.Box(new Rect(curX - 10, 0, normWidth + 10, Screen.height), base.getMenuName());
            GUI.Box(new Rect(curX - 10, 0, normWidth + 10, Screen.height), base.getMenuName());
            GUI.Box(new Rect(curX - 10, 0, normWidth + 10, Screen.height), base.getMenuName());
            incrementY(5);
            mods.isGodMode = GUI.Toggle(new Rect(curX, curY, normWidth, normHeight / 5), mods.isGodMode, "God Mode");
            incrementY(5);

        }

        public override void onUpdate()
        {
            mods.onUpdate();
        }
    }
}
