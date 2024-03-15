using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Service
{
    public class EventService
    {
        private static EventService instance;
        public static EventService Instance 
        { 
            get
            {
                if(instance == null)
                {
                    instance = new EventService();
                }
                return instance;
            } 
        }

        public EventController OnLightSwitchToggled;
        private EventService()
        {
            OnLightSwitchToggled = new EventController();
        }
    }
}
