using System.Collections;
using System.Collections.Generic;
using System;

namespace Vastav.Player.EventsData
{
    public static class Player_EventManager
    {
        public static Action OnJump;
        public static Action<float> OnMove;

        public static Action OnInteractSwitch;
        public static Action OnFire;
    }
}

