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
        onRender
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
            eventList.Add(EventNames.onUpdate, new List<Module>());
            eventList.Add(EventNames.onRender, new List<Module>());
        }

        public void onUpdate()
        {
            foreach(Module mod in eventList[EventNames.onUpdate])
            {
                mod.onUpdate();
            }
        }

        public void onRender()
        {
            foreach(Module mod in eventList[EventNames.onRender])
            {
                mod.onDraw();
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
