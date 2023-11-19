using UnityEngine;
using UnityEngine.Events;
using Vastav.Player;
using Vastav.UI;

namespace Vastav.Player.Switch
{
    public class DoorManager : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerInput inputManager = collision.GetComponent<PlayerInput>();
            if (inputManager != null)
            {
                collision.GetComponent<PlayerMovement>().enabled = false;
                inputManager.enabled = false;
                AudioManager.Instance.PlayEffect(SoundType.Win);
                UIInputManager.Instance.OnWin?.Invoke();
            }
        }
    }
}