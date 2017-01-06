using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using PPForestTrn.Hack.Managers;

namespace PPForestTrn.Hack.Mods
{
    class Module
    {
        private string moduleName = "GenericModule";
        private KeyCode moduleBind = KeyCode.None;
        private Categories moduleCategory = Categories.mNone;
        private bool moduleState = false;
        private GuiNames moduleGuiElement = GuiNames.None;

        public float sliderValue = 0;
        public string textBoxString = "Text";

        public float maxSliderValue = 1;    //NEEDS TO BE SET
        public float minSliderValue = 0;

        protected Module(string name, KeyCode bind = KeyCode.None, Categories category = Categories.mNone, GuiNames elementName = GuiNames.None)
        {
            this.moduleName = name;
            this.moduleBind = bind;
            this.moduleCategory = category;
            this.moduleGuiElement = elementName;
        }

        public virtual void onUpdate() { }
        public virtual void onDraw() { }
        public virtual void onPostRender() { }
        public virtual void onEnable() { }
        public virtual void onDisable() { }
        public virtual void onToggle() { }
        public virtual void onButtonPress() { }

        public void setState(bool state)
        {
            if(state != this.moduleState)
                if (state)
                    this.enable();
                else
                    this.disable();
        }

        public void enable()
        {
            if (!this.moduleState)
            {
                this.moduleState = true;
                onToggle();
            }
            onEnable();
        }

        public void disable()
        {
            if(this.moduleState)
            {
                this.moduleState = false;
                onToggle();
            }
            onDisable();
        }

        public void toggle()
        {
            this.moduleState = !this.moduleState;

            onToggle();

            if (this.moduleState)
                onEnable();
            else
                onDisable();
        }

        public string getName()
        {
            return this.moduleName;
        }

        public bool getState()
        {
            return this.moduleState;
        }

        public Categories getCategory()
        {
            return this.moduleCategory;
        }

        public KeyCode getBind()
        {
            return this.moduleBind;
        }

        public void setBind(KeyCode key)
        {
            this.moduleBind = key;
        }

        public GuiNames getGuiElement()
        {
            return this.moduleGuiElement;
        }
    }
}
