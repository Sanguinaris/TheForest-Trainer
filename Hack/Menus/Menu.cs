using PPForestTrn.Hack.Managers;
using PPForestTrn.Hack.Mods;
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
        private Categories menuCategory;

        protected Menu(string name, KeyCode code, Categories category)
        {
            this.menuName = name;
            this.menuKey = code;
            this.menuCategory = category;
        }

        public virtual void onStart() { }

        public virtual void onUpdate() { }

        private float scrollValue = 0;



        public virtual void drawGui() {
            resetDrawMath();
            GUI.Box(new Rect(curX - 10, 0, normWidth + 10, Screen.height), this.getMenuName());
            GUI.Box(new Rect(curX - 10, 0, normWidth + 10, Screen.height), this.getMenuName());
            GUI.Box(new Rect(curX - 10, 0, normWidth + 10, Screen.height), this.getMenuName());
            GUI.Box(new Rect(curX - 10, 0, normWidth + 10, Screen.height), this.getMenuName());
            scrollValue = GUI.VerticalScrollbar(new Rect(curX + normWidth, 0, 100, Screen.height), scrollValue, 1.0f, (oldY - Screen.height > 0) ? oldY - Screen.height : 0.1f, 0);
            incrementY(6);

            foreach (Module mod in ModMgr.Instance.getAllMods())
            {
                if (mod.getCategory() != this.menuCategory)
                    continue;

                switch(mod.getGuiElement())
                {
                    case GuiNames.Button:
                        if (GUI.Button(new Rect(curX, curY - scrollValue, normWidth, normHeight / 2), mod.getName()))
                            mod.onButtonPress();
                        incrementY(2);
                        break;
                    case GuiNames.ButtonWSlider:
                        if (GUI.Button(new Rect(curX, curY - scrollValue, normWidth, normHeight / 2), mod.getName() + ": " + mod.sliderValue.ToString()))
                            mod.onButtonPress();
                        incrementY(2);
                        mod.sliderValue = GUI.HorizontalSlider(new Rect(curX, curY - scrollValue, normWidth / 2, normHeight / 4), mod.sliderValue, mod.minSliderValue, mod.maxSliderValue);
                        incrementY(4);
                        break;
                    case GuiNames.ButtonWText:
                        mod.textBoxString = GUI.TextField(new Rect(curX + normWidth / 2, curY - scrollValue, normWidth / 2, normHeight / 4), mod.textBoxString);
                        if (GUI.Button(new Rect(curX, curY - scrollValue, normWidth / 2, normHeight / 2), mod.getName()))
                            mod.onButtonPress();
                        incrementY(2);
                        break;
                    case GuiNames.Toggle:
                        mod.setState(GUI.Toggle(new Rect(curX, curY - scrollValue, normWidth, normHeight / 5), mod.getState(), mod.getName()));
                        incrementY(5);
                        break;
                }
            }
        }

        public virtual string getMenuName() { return this.menuName; }
        public virtual KeyCode getMenuBind() { return this.menuKey; }

        //Drawing Stuff
        protected float curX = 0, curY = 0, normPad = 0, normWidth = 0, normHeight = 0, oldY = 0;
        protected void resetDrawMath() { oldY = curY; curX = Screen.width * 3 / 8;  curY = 0; normPad = Screen.height / 100; normWidth = Screen.width / 4; normHeight = Screen.height / 5; }
        protected void incrementY(int divider) { curY += normHeight / divider + normPad; }
    }
}
