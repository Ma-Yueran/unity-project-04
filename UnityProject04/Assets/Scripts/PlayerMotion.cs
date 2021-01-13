﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    /// <summary>
    /// PlayerMotion handles inputs related to character motion from PlayerControls, 
    /// also updates character animations using AnimatorHandler.
    /// </summary>
    public class PlayerMotion : MonoBehaviour
    {
        public float walkSpeed = 2.5f;
        public float runSpeed = 4f;
        public float fallingForwardSpeed = 1.5f;

        private Transform myTransform;
        private PlayerControls playerControls;
        private AnimatorHandler animatorHandler;
        private GroundCheck groundCheck;

        private void Awake()
        {
            myTransform = transform;
            playerControls = GetComponent<PlayerControls>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            groundCheck = GetComponentInChildren<GroundCheck>();
        }

        public void HandleMovement()
        {
            if (animatorHandler.GetCanRotate())
            {
                HandleRotation();
            }

            if (animatorHandler.GetIsInteracting() || animatorHandler.GetIsFalling())
            {
                return;
            }

            if (!playerControls.isMoving)
            {
                // Set animation state
                animatorHandler.SetState(AnimatorHandler.IDLE);
                return;
            }

            if (playerControls.dodgeFlag)
            {
                animatorHandler.PlayAnimation("Sword1h_Dodge_Fwd", true);
            }
            else if (playerControls.isRunning)
            {
                myTransform.position += playerControls.GetTargetDirection() * runSpeed * Time.deltaTime;
                // Set animation state
                animatorHandler.SetState(AnimatorHandler.RUN);
            }
            else
            {
                myTransform.position += playerControls.GetTargetDirection() * walkSpeed * Time.deltaTime;
                // Set animation state
                animatorHandler.SetState(AnimatorHandler.WALK);
            }
        }

        private void HandleRotation()
        {
            if (!playerControls.isMoving)
            {
                return;
            }

            Quaternion targetDirection = Quaternion.LookRotation(playerControls.GetTargetDirection());
            myTransform.rotation = Quaternion.Lerp(myTransform.rotation, targetDirection, 0.05f);
        }

        public void HandleFalling()
        {
            if (groundCheck.IsGoingToFall())
            {
                animatorHandler.SetIsFalling(true);
                transform.position += transform.forward * fallingForwardSpeed * Time.deltaTime;
                
            }

            if (groundCheck.IsLanding())
            {
                animatorHandler.SetIsFalling(false);
            }
        }
    }
}
