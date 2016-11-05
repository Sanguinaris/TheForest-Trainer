using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPForestTrn.Hack;
using UnityEngine;

namespace PPForestTrn
{
    public class HackCtor
    {
        public static bool wasInit = false;
        //HOOK MAIN MENU AUDIO
        public static void Load()
        {
            if (wasInit) return;
            wasInit = true;
            GameObject gameObject = new GameObject();   //An object
            gameObject.AddComponent<Base>();            //which we add our class to
            UnityEngine.Object.DontDestroyOnLoad(gameObject);//and which shouldnt get destroyed
        }

    }
}
