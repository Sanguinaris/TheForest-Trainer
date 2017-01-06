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

        private float orginalWidth = 640;
        private float orginalHeight = 400;
        private Vector3 scale;


        public virtual void drawGui() {
            resetDrawMath();

            scale.x = Screen.width / orginalWidth;
            scale.y = Screen.height / orginalHeight;
            scale.z = 1;

            Matrix4x4 origMatrix = GUI.matrix;
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);

            GUI.Box(new Rect(230, 0, 170, 400), this.getMenuName());
            GUI.Box(new Rect(230, 0, 170, 400), this.getMenuName());
            GUI.Box(new Rect(230, 0, 170, 400), this.getMenuName());
            GUI.Box(new Rect(230, 0, 170, 400), this.getMenuName());
            scrollValue = GUI.VerticalScrollbar(new Rect(400, 0, 100, 400), scrollValue, 1.0f, (oldY - 400 > 0) ? oldY - Screen.height : 0.1f, 0);
            incrementY(6);
            GUI.BeginGroup(new Rect(240, 0, 160, 400));
            foreach (Module mod in ModMgr.Instance.getAllMods())
            {
                if (mod.getCategory() != this.menuCategory)
                    continue;

                switch(mod.getGuiElement())
                {
                    case GuiNames.Button:
                        if (GUI.Button(new Rect(0, curY - scrollValue, 160, 40), mod.getName()))
                            mod.onButtonPress();
                        incrementY(2);
                        break;
                    case GuiNames.ButtonWSlider:
                        if (GUI.Button(new Rect(0, curY - scrollValue, 160, 80 / 2), mod.getName() + ": " + mod.sliderValue.ToString()))
                            mod.onButtonPress();
                        incrementY(2);
                        mod.sliderValue = GUI.HorizontalSlider(new Rect(0, curY - scrollValue, 160, 80 / 4), mod.sliderValue, mod.minSliderValue, mod.maxSliderValue);
                        incrementY(4);
                        break;
                    case GuiNames.ButtonWText:
                        mod.textBoxString = GUI.TextField(new Rect(150, curY - scrollValue, 80, 80 / 4), mod.textBoxString);
                        if (GUI.Button(new Rect(0, curY - scrollValue, 80, 80 / 2), mod.getName()))
                            mod.onButtonPress();
                        incrementY(2);
                        break;
                    case GuiNames.Toggle:
                        mod.setState(GUI.Toggle(new Rect(0, curY - scrollValue, 160, 80 / 5), mod.getState(), mod.getName()));
                        incrementY(5);
                        break;
                }
            }
            GUI.color = Color.yellow;
            GUI.Label(new Rect(15, 380, 130, 20), "PiratePerfection.com");
            GUI.color = Color.white;
            GUI.EndGroup();
            GUI.matrix = origMatrix;
        }

        public virtual string getMenuName() { return this.menuName; }
        public virtual KeyCode getMenuBind() { return this.menuKey; }

        //Drawing Stuff
        protected float curX = 0, curY = 0, normPad = 0, normWidth = 0, normHeight = 0, oldY = 0;
        protected void resetDrawMath() { oldY = curY; curX = Screen.width * 3 / 8;  curY = 0; normPad = Screen.height / 100; normWidth = Screen.width / 4; normHeight = Screen.height / 5; }
        protected void incrementY(int divider) { curY += 80 / divider + 12; }
    }
}

