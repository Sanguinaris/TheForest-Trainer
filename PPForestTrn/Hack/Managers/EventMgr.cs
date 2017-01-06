using PPForestTrn.Hack.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPForestTrn.Hack.Managers
{
    public enum EventNames
    {
        onUpdate,
        onGui,
        onPostRender
    };

    class EventMgr
    {
        static readonly EventMgr _instance = new EventMgr();

        public static EventMgr Instance
        {
            get
            {
                return _instance;
            }
        }

        Dictionary<EventNames, List<Module>> eventList = new Dictionary<EventNames, List<Module>>();

        public EventMgr() {
            foreach(EventNames ev in Enum.GetValues(typeof(EventNames)))
            {
                eventList.Add(ev, new List<Module>());
            }
        }

        public void onUpdate()
        {
            foreach(Module mod in eventList[EventNames.onUpdate])
            {
                mod.onUpdate();
            }
        }

        public void onGui()
        {
            foreach(Module mod in eventList[EventNames.onGui])
            {
                mod.onDraw();
            }
        }

        public void onPostRender()
        {
            foreach (Module mod in eventList[EventNames.onPostRender])
            {
                mod.onPostRender();
            }
        }

        public void registerEventListener(EventNames name, Module mod)
        {
            eventList[name].Add(mod);
        }

        public void deleteEventListener(EventNames name, Module mod)
        {
            eventList[name].Remove(mod);
        }
    }
}
