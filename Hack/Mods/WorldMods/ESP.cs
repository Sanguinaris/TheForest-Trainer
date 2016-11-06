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
        public ESP() : base("ESP", UnityEngine.KeyCode.None, Categories.mWorld, GuiNames.Toggle)
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

        public Color color = Color.green;

        private Vector3 v3FrontTopLeft;
        private Vector3 v3FrontTopRight;
        private Vector3 v3FrontBottomLeft;
        private Vector3 v3FrontBottomRight;
        private Vector3 v3BackTopLeft;
        private Vector3 v3BackTopRight;
        private Vector3 v3BackBottomLeft;
        private Vector3 v3BackBottomRight;

        public override void onUpdate()
        {
            if (!this.getState()) return;
            CalcPositons();
            DrawBox();
        }

        void CalcPositons()
        {
            foreach (GameObject cannibals in TheForest.Utils.Scene.MutantControler.activeCannibals)
            {

                //Bounds bounds = cannibals.GetComponent<MeshFilter>().mesh.bounds;

                Bounds bounds;
                BoxCollider bc = cannibals.GetComponent<BoxCollider>();
                if (bc != null)
                    bounds = bc.bounds;
                else
                    return;

                Vector3 v3Center = bounds.center;
                Vector3 v3Extents = bounds.extents;

                v3FrontTopLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y + v3Extents.y, v3Center.z - v3Extents.z);  // Front top left corner
                v3FrontTopRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y + v3Extents.y, v3Center.z - v3Extents.z);  // Front top right corner
                v3FrontBottomLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y - v3Extents.y, v3Center.z - v3Extents.z);  // Front bottom left corner
                v3FrontBottomRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y - v3Extents.y, v3Center.z - v3Extents.z);  // Front bottom right corner
                v3BackTopLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y + v3Extents.y, v3Center.z + v3Extents.z);  // Back top left corner
                v3BackTopRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y + v3Extents.y, v3Center.z + v3Extents.z);  // Back top right corner
                v3BackBottomLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y - v3Extents.y, v3Center.z + v3Extents.z);  // Back bottom left corner
                v3BackBottomRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y - v3Extents.y, v3Center.z + v3Extents.z);  // Back bottom right corner


                v3FrontTopLeft = cannibals.transform.TransformPoint(v3FrontTopLeft);
                v3FrontTopRight = cannibals.transform.TransformPoint(v3FrontTopRight);
                v3FrontBottomLeft = cannibals.transform.TransformPoint(v3FrontBottomLeft);
                v3FrontBottomRight = cannibals.transform.TransformPoint(v3FrontBottomRight);
                v3BackTopLeft = cannibals.transform.TransformPoint(v3BackTopLeft);
                v3BackTopRight = cannibals.transform.TransformPoint(v3BackTopRight);
                v3BackBottomLeft = cannibals.transform.TransformPoint(v3BackBottomLeft);
                v3BackBottomRight = cannibals.transform.TransformPoint(v3BackBottomRight);
                DrawBox();
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

        void DrawBox()
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
        }
    }
}
