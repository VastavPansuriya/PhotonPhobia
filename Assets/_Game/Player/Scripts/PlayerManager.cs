using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vastav.UI;

namespace Vastav.Player
{
    public class PlayerManager : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Danger"))
            {
                AudioManager.Instance.PlayEffect(SoundType.Loss);
                UIInputManager.Instance.OnLoss?.Invoke();
            }
        }
    }
}