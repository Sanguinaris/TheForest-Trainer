using PPForestTrn.Hack.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PPForestTrn.Hack
{
    public class Base : MonoBehaviour
    {
        [DllImport("Dx11DrawingTools.dll", EntryPoint = "InitDx11")]
        public static extern void InitDx11();

        private void Start()
        {
            MenuMgr.Instance.onStart();
        }

        private void Update()
        {
            MenuMgr.Instance.onUpdate();
            ModMgr.Instance.onUpdate();
            EventMgr.Instance.onUpdate();
        }

        private void OnGUI()
        {
            MenuMgr.Instance.onGUI();
            EventMgr.Instance.onGui();
        }

        private void OnPostRender()
        {
            EventMgr.Instance.onPostRender();
        }
    }
}
