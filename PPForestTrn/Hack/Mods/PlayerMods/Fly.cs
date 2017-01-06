using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPForestTrn.Hack.Managers;
using UnityEngine;

namespace PPForestTrn.Hack.Mods.PlayerMods
{
    class Fly : Module
    {
        public Fly() : base("Fly", KeyCode.None, Categories.mPlayer, GuiNames.Toggle)
        {
        }

        public override void onEnable()
        {
            EventMgr.Instance.registerEventListener(EventNames.onUpdate, this);
        }

        public override void onDisable()
        {
            EventMgr.Instance.deleteEventListener(EventNames.onUpdate, this);
            TheForest.Utils.LocalPlayer.FpCharacter.rb.useGravity = true;
            TheForest.Utils.LocalPlayer.FpCharacter.GetComponent<CapsuleCollider>().enabled = true;
            TheForest.Utils.LocalPlayer.FpCharacter.GetComponent<SphereCollider>().enabled = true;

        }

        public override void onUpdate()
        {
            if (!this.getState()) return;
            TheForest.Utils.LocalPlayer.FpCharacter.checkGrounded = true;
            TheForest.Utils.LocalPlayer.FpCharacter.rb.useGravity = false;
            TheForest.Utils.LocalPlayer.FpCharacter.GetComponent<CapsuleCollider>().enabled = !ModMgr.Instance.getModuleByName("No Clip Mode").getState();
            TheForest.Utils.LocalPlayer.FpCharacter.GetComponent<SphereCollider>().enabled = !ModMgr.Instance.getModuleByName("No Clip Mode").getState();

            Vector3 velocity = TheForest.Utils.LocalPlayer.FpCharacter.rb.velocity;
            float baseSpeed = 25f;

            if (Input.GetButton("Run"))
            {
                baseSpeed = TheForest.Utils.LocalPlayer.FpCharacter.runSpeed * 1.5f;
            }
            if(Input.GetButton("Jump"))
            {
                velocity.y -= baseSpeed;
            }
            if(Input.GetButton("Crouch"))
            {
                velocity.y += baseSpeed;
            }
            Vector3 force = ((Vector3)(Camera.main.transform.rotation * (new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * baseSpeed))) - velocity;
            TheForest.Utils.LocalPlayer.FpCharacter.rb.AddForce(force, ForceMode.VelocityChange);
        }
    }
}
