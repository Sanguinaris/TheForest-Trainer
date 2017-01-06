using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using PPForestTrn.Hack.Menus;

namespace PPForestTrn.Hack.Managers
{
    class MenuMgr
    {
        static readonly MenuMgr _instance = new MenuMgr();

        public static MenuMgr Instance
        {
            get
            {
                return _instance;
            }
        }

        private List<Menu> menuList = new List<Menu>();
        private int curActiveMenu = -1;

        public MenuMgr()
        {
            menuList.Add(new PlayerMenu());
            menuList.Add(new InventoryMenu());
            menuList.Add(new WorldMenu());
        }

        public void onStart()
        {
            foreach(Menu menu in menuList)
            {
                menu.onStart();
            }
        }

        bool wasMenuOn = false;
        bool hadUnlockedView = false;
       // float oldTime = 1;

        public void onUpdate()
        {
            for(int i = 0; i < menuList.Count; i++)
            {
                if(Input.GetKeyDown(menuList[i].getMenuBind()))
                {
                    if (i == curActiveMenu)
                        curActiveMenu = -1;
                    else
                        this.curActiveMenu = i;
                }

                menuList[i].onUpdate();
            }

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                curActiveMenu = -1;
            }

            if(curActiveMenu >= 0)
            {
                // if (TheForest.Utils.LocalPlayer.Inventory.CurrentView != TheForest.Items.Inventory.PlayerInventory.PlayerViews.Pause)
                // {
                //oldView = TheForest.Utils.LocalPlayer.Inventory.CurrentView;
                //TheForest.Utils.LocalPlayer.Inventory.CurrentView = TheForest.Items.Inventory.PlayerInventory.PlayerViews.Pause;
                wasMenuOn = true;
                if (TheForest.Utils.Input.IsMouseLocked)
                {
                    TheForest.Utils.LocalPlayer.FpCharacter.LockView(true);
                    TheForest.Utils.LocalPlayer.Create.CloseBuildMode();
                    if (!BoltNetwork.isRunning)
                    {
                        Time.timeScale = 0f;
                        TheForest.Utils.LocalPlayer.PauseMenuBlur.enabled = true;
                        TheForest.Utils.LocalPlayer.PauseMenuBlurPsCam.enabled = true;
                    }
                    TheForest.Utils.Scene.HudGui.GuiCam.SetActive(false);


                    hadUnlockedView = true;
                }
            }else if(wasMenuOn)
            {
                wasMenuOn = false;
                if (hadUnlockedView)
                {
                    TheForest.Utils.LocalPlayer.FpCharacter.UnLockView();
                    TheForest.Utils.Scene.HudGui.CheckHudState();
                    Time.timeScale = 1f;
                    TheForest.Utils.LocalPlayer.PauseMenuBlur.enabled = false;
                    TheForest.Utils.LocalPlayer.PauseMenuBlurPsCam.enabled = false;
                    TheForest.Utils.Scene.HudGui.CheckHudState();


                    hadUnlockedView = false;
                }
            }
        }

        public void onGUI()    //if cant get overriden then use another fúnc name
        {
            if (curActiveMenu >= 0)
                menuList[curActiveMenu].drawGui();
        }
    }
}
