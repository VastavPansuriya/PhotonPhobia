using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vastav.Player.EventsData;

namespace Vastav.Player
{
    public class PlayerInput : MonoBehaviour
    {
        [Header("PlayerJump Settings")]
        [SerializeField] private Transform groundCheckPoint;
        [SerializeField] private float groundCheckRadius;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private float maxJumpTime;
        private float remainedJumpTime;

        //Movement
        private float moveX;


        private bool isJump;
        private float startForce;
        private void Update()
        {
            MovementInput();
            JumpInput();
            InteractInput();
        }

        private void FixedUpdate()
        {
            Player_EventManager.OnMove?.Invoke(moveX);
        }

        private void MovementInput()
        {
            moveX = Input.GetAxisRaw("Horizontal");
        }

        private void JumpInput()
        {
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
            }
            if (Input.GetKey(KeyCode.Space))
            {
                if (IsGrounded() && isJump)
                {
                    remainedJumpTime = maxJumpTime;
                    isJump = false;
                }
                else
                {
                    remainedJumpTime -= Time.deltaTime;
                }
                if (remainedJumpTime > 0)
                {
                    Player_EventManager.OnJump?.Invoke();
                }
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                remainedJumpTime = 0;
                isJump = false;
            }
        }

        private void InteractInput()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player_EventManager.OnInteractSwitch?.Invoke();
            }
        }

        private bool IsGrounded()
        {
            bool isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

            return isGrounded;
        }
    }

}
