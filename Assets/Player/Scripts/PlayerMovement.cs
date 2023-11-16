using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vastav.Player.EventsData;

namespace Vastav.Player
{

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("PlayerMovement Settings")]
        [SerializeField] private float speed; 
        [SerializeField] private float jumpForce;

       


        //Reference
        private Rigidbody2D playerRb;

        private void Awake()
        {
            playerRb = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            Player_EventManager.OnJump += OnJump;
            Player_EventManager.OnMove += Move;
        }


        private void Move(float moveX)
        {
            SpriteFlip(moveX);
            playerRb.velocity = new Vector2(moveX * speed, playerRb.velocity.y);
        }

        private void SpriteFlip(float moveX)
        {
            if (moveX != 0)
            {
                if (moveX > 0)
                {
                    transform.eulerAngles = Vector3.zero;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
            }
        }

        private void OnJump()
        {
            playerRb.velocity = Vector2.up * jumpForce;
        }

        private void OnDisable()
        {
            Player_EventManager.OnJump -= OnJump;
            Player_EventManager.OnMove -= Move;
        }
    }
}

