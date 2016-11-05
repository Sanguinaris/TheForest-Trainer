using PPForestTrn.Hack.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PPForestTrn.Hack
{
    public class Base : MonoBehaviour
    {
        MenuMgr menuMgr = new MenuMgr();

        private void Start()
        {
            menuMgr.onStart();
        }

        private void Update()
        {
            menuMgr.onUpdate();
        }

        private void OnGUI()
        {
            GUI.color = new Color(255, 255, 0);
            GUI.Label(new Rect(10, 10, 130, 20), "PiratePerfection.com");
            GUI.color = new Color(255, 255, 255);
            menuMgr.onGUI();
        }
    }
}
