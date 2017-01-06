using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPForestTrn.Hack.Managers;
using UnityEngine;
using System.Runtime.InteropServices;

namespace PPForestTrn.Hack.Mods.WorldMods
{
    class ESP : Module
    {
        public ESP() : base("ESP", KeyCode.None, Categories.mWorld, GuiNames.Toggle)
        {
        }

        public override void onEnable()
        {
            EventMgr.Instance.registerEventListener(EventNames.onPostRender, this);
        }

        public override void onDisable()
        {
            EventMgr.Instance.deleteEventListener(EventNames.onPostRender, this);
        }

        private Material mat;

        public override void onPostRender()
        {
            foreach (GameObject cannibals in TheForest.Utils.Scene.MutantControler.activeWorldCannibals)
            {
                DrawEsp(cannibals.transform);
            }
            foreach (GameObject cannibals in TheForest.Utils.Scene.MutantControler.activeBabies)
            {
                DrawEsp(cannibals.transform);
            }
            foreach (GameObject cannibals in TheForest.Utils.Scene.MutantControler.activeCannibals)
            {
                DrawEsp(cannibals.transform);
            }
            foreach (GameObject cannibals in TheForest.Utils.Scene.MutantControler.activeFamilies)
            {
                DrawEsp(cannibals.transform);
            }
            foreach (GameObject cannibals in TheForest.Utils.Scene.MutantControler.activeInstantSpawnedCannibals)
            {
                DrawEsp(cannibals.transform);
            }
            foreach (GameObject cannibals in TheForest.Utils.Scene.MutantControler.activeSkinnyCannibals)
            {
                DrawEsp(cannibals.transform);
            }
        }

        void DrawEsp(Transform transform)
        {
            Vector3 screenPos = TheForest.Utils.LocalPlayer.MainCam.WorldToScreenPoint(transform.position);

            if (!mat)
            {
                // Unity has a built-in shader that is useful for drawing
                // simple colored things. In this case, we just want to use
                // a blend mode that inverts destination colors.
                Shader shader = Shader.Find("Hidden/Internal-Colored");
                mat = new Material(shader);
                mat.hideFlags = HideFlags.HideAndDontSave;
                // Set blend mode to invert destination colors.
                mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusDstColor);
                mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                // Turn off backface culling, depth writes, depth test.
                mat.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
                mat.SetInt("_ZWrite", 0);
                mat.SetInt("_ZTest", (int)UnityEngine.Rendering.CompareFunction.Always);
            }

            GL.PushMatrix();
            GL.LoadOrtho();

            // activate the first shader pass (in this case we know it is the only pass)
            mat.SetPass(0);
            // draw a quad over whole screen
            GL.Begin(GL.QUADS);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(1, 0, 0);
            GL.Vertex3(1, 1, 0);
            GL.Vertex3(0, 1, 0);
            GL.End();

            GL.PopMatrix();
        }
    }
}
