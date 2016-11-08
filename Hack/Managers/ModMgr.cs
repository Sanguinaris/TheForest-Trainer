using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPForestTrn.Hack.Mods;
using PPForestTrn.Hack.Mods.PlayerMods;
using PPForestTrn.Hack.Mods.WorldMods;
using UnityEngine;
using PPForestTrn.Hack.Mods.InventoryMods;

namespace PPForestTrn.Hack.Managers
{
    public enum Categories{
        mNone,
        mPlayer,
        mInventory,
        mWorld,
        mCount
    };

    public enum GuiNames
    {
        None,
        Toggle,
        Button,
        ButtonWSlider,
        ButtonWText,
        Count
    };

    class ModMgr
    {
        static readonly ModMgr _instance = new ModMgr();

        public static ModMgr Instance
        {
            get
            {
                return _instance;
            }
        }

        List<Module> moduleList = new List<Module>();

        public ModMgr()
        {
            moduleList.Add(new GodMode());
            moduleList.Add(new InfiniteStamina());
            moduleList.Add(new NoStarvation());
            moduleList.Add(new NoThirst());
            moduleList.Add(new NoFallDamage());
            moduleList.Add(new SpeedHack());
            moduleList.Add(new HighJump());
            moduleList.Add(new ESP());
            moduleList.Add(new InfiniteSpace());
            moduleList.Add(new KillAll());
            moduleList.Add(new InfiniteArmour());
            moduleList.Add(new InfiniteOxygen());
            moduleList.Add(new InfiniteSanity());
            moduleList.Add(new NoClip());
            moduleList.Add(new Fly());
            moduleList.Add(new CaveLight());
        }

        private void dispatchKeyEvents()
        {
            foreach(Module mod in moduleList)
            {
                if(Input.GetKeyDown(mod.getBind()))
                {
                    mod.toggle();
                }
            }
        }

        public void onUpdate()
        {
            dispatchKeyEvents();
        }

        public Module getModuleByName(string name)
        {
            foreach(Module mod in moduleList)
            {
                if (mod.getName() == name)
                    return mod;
            }
            return null;
        }

        public List<Module> getAllMods()
        {
            return moduleList;
        }

        public int getModuleListCount()
        {
            return moduleList.Count;
        }
    }
}
