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
        private List<Menu> menuList = new List<Menu>();
        private int curActiveMenu = -1;

        public MenuMgr()
        {
            menuList.Add(new PlayerMenu());
        }

        public void onStart()
        {
            foreach(Menu menu in menuList)
            {
                menu.onStart();
            }
        }

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
        }

        public void onGUI()    //if cant get overriden then use another fúnc name
        {
            if (curActiveMenu >= 0)
                menuList[curActiveMenu].drawGui();
        }
    }
}
