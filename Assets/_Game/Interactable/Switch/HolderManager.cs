using UnityEngine;
using UnityEngine.Events;
using Vastav.Enums;



namespace Vastav.Player.Switch
{
    public class HolderManager : MonoBehaviour
    {
        public SwitchState curruntState;

        public Transform switchHolder;

        public UnityEvent OnFilled;

        private bool isSwitchUsed;

        private void Start()
        {
            isSwitchUsed = false;
        }

        private void Update()
        {
            if (curruntState == SwitchState.filled && !isSwitchUsed)
            {
                OnFilled?.Invoke();
                isSwitchUsed = true;
            }
        }
    }
}
