using PPForestTrn.Hack.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PPForestTrn.Hack.Mods.WorldMods
{
    class ESP : Module
    {
        public ESP() : base("Snap lines", UnityEngine.KeyCode.None, Categories.mWorld, GuiNames.Toggle)
        {
        }

        public override void onEnable()
        {
            EventMgr.Instance.registerEventListener(EventNames.onUpdate, this);

        }

        public override void onDisable()
        {
            EventMgr.Instance.deleteEventListener(EventNames.onUpdate, this);
        }

        public Color color = Color.red;

        public override void onUpdate()
        {
            if (!this.getState()) return;
            CalcPositons();
            //DrawBox();
        }

        void CalcPositons()
        {
            foreach (GameObject cannibals in TheForest.Utils.Scene.MutantControler.activeWorldCannibals)
            {
                DrawLine(TheForest.Utils.LocalPlayer.Transform.position, cannibals.transform.position, color, 0.03f);
            }
            foreach (GameObject cannibals in TheForest.Utils.Scene.MutantControler.activeBabies)
            {
                DrawLine(TheForest.Utils.LocalPlayer.Transform.position, cannibals.transform.position, color, 0.03f);
            }
            foreach (GameObject cannibals in TheForest.Utils.Scene.MutantControler.activeCannibals)
            {
                DrawLine(TheForest.Utils.LocalPlayer.Transform.position, cannibals.transform.position, color, 0.03f);
            }
            foreach (GameObject cannibals in TheForest.Utils.Scene.MutantControler.activeFamilies)
            {
                DrawLine(TheForest.Utils.LocalPlayer.Transform.position, cannibals.transform.position, color, 0.03f);
            }
            foreach (GameObject cannibals in TheForest.Utils.Scene.MutantControler.activeInstantSpawnedCannibals)
            {
                DrawLine(TheForest.Utils.LocalPlayer.Transform.position, cannibals.transform.position, color, 0.03f);
            }
            foreach (GameObject cannibals in TheForest.Utils.Scene.MutantControler.activeSkinnyCannibals)
            {
                DrawLine(TheForest.Utils.LocalPlayer.Transform.position, cannibals.transform.position, color, 0.03f);
            }
        }

        void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0.2f)
        {
            GameObject myLine = new GameObject();
            myLine.transform.position = start;
            myLine.AddComponent<LineRenderer>();
            LineRenderer lr = myLine.GetComponent<LineRenderer>();
            lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
            lr.SetColors(color, color);
            lr.SetWidth(0.1f, 0.1f);
            lr.SetPosition(0, start);
            lr.SetPosition(1, end);
            GameObject.Destroy(myLine, duration);
        }

        /*void DrawBox()
        {
            //if (Input.GetKey (KeyCode.S)) {
            DrawLine(v3FrontTopLeft, v3FrontTopRight, color);
            DrawLine(v3FrontTopRight, v3FrontBottomRight, color);
            DrawLine(v3FrontBottomRight, v3FrontBottomLeft, color);
            DrawLine(v3FrontBottomLeft, v3FrontTopLeft, color);

            DrawLine(v3BackTopLeft, v3BackTopRight, color);
            DrawLine(v3BackTopRight, v3BackBottomRight, color);
            DrawLine(v3BackBottomRight, v3BackBottomLeft, color);
            DrawLine(v3BackBottomLeft, v3BackTopLeft, color);

            DrawLine(v3FrontTopLeft, v3BackTopLeft, color);
            DrawLine(v3FrontTopRight, v3BackTopRight, color);
            DrawLine(v3FrontBottomRight, v3BackBottomRight, color);
            DrawLine(v3FrontBottomLeft, v3BackBottomLeft, color);
            //}
        }*/
    }
}
