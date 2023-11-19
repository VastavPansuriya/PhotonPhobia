using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vastav.Enums;

namespace Vastav.Player.Switch
{
    public class SwitchManager : MonoBehaviour
    {


        public static Action OnStateChange;

        private void OnEnable()
        {
            OnStateChange += ChangeState;
        }

        private void ChangeState()
        {
            throw new NotImplementedException();
        }

        private void OnDisable()
        {
            OnStateChange -= ChangeState;
        }
    }

}

