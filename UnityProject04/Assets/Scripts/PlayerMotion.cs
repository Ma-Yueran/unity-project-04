using System.Collections;
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
        public float walkSpeed = 3;
        public float runSpeed = 6;

        private Transform myTransform;
        private PlayerControls playerControls;
        private AnimatorHandler animatorHandler;

        private void Awake()
        {
            myTransform = transform;
            playerControls = GetComponent<PlayerControls>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }

        public void HandleMovement()
        {
            if (animatorHandler.animator.GetBool("IsInteracting"))
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

            HandleRotation();
        }

        private void HandleRotation()
        {
            Quaternion targetDirection = Quaternion.LookRotation(playerControls.GetTargetDirection());
            myTransform.rotation = Quaternion.Lerp(myTransform.rotation, targetDirection, 0.1f);
        }
    }
}
