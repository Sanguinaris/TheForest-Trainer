using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PPForestTrn.Hack.Menus
{
    class Menu
    {
        private string menuName;
        private KeyCode menuKey;

        protected Menu(string name, KeyCode code)
        {
            this.menuName = name;
            this.menuKey = code;
        }

        public virtual void onStart() { }

        public virtual void onUpdate() { }

        public virtual void drawGui() { }

        public virtual string getMenuName() { return this.menuName; }
        public virtual KeyCode getMenuBind() { return this.menuKey; }

        //Drawing Stuff
        protected float curX = 0, curY = 0, normPad = 0, normWidth = 0, normHeight = 0;
        protected void resetDrawMath() { curX = Screen.width * 3 / 8;  curY = 0; normPad = Screen.width / 25; normWidth = Screen.width / 4; normHeight = Screen.height / 5; }
        protected void incrementY(int divider) { curY += Screen.height / 5 / divider + normPad; }
    }
}
