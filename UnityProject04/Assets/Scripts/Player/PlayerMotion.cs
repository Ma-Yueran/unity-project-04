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
        public float walkSpeed = 2.5f;
        public float runSpeed = 4f;
        public float lockWalkSpeed = 2f;
        public float fallingForwardSpeed = 1.5f;
        public float rotateSpeed = 10f;

        private Transform myTransform;
        private PlayerControls playerControls;
        private AnimatorHandler animatorHandler;
        private GroundCheck groundCheck;
        private ThirdPersonCamera thirdPersonCamera;

        private void Awake()
        {
            myTransform = transform;
            playerControls = GetComponent<PlayerControls>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            groundCheck = GetComponentInChildren<GroundCheck>();
        }

        private void Start()
        {
            thirdPersonCamera = ThirdPersonCamera.instance;
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

            if (thirdPersonCamera.isLockingOn)
            {
                HandleLockOnMovement();

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
            float rotateSpeed;
            Quaternion targetRotation;

            if (thirdPersonCamera.isLockingOn && animatorHandler.GetCanRotate())
            {
                targetRotation = Quaternion.LookRotation(thirdPersonCamera.currentLockOn.position - myTransform.position);
                rotateSpeed = Mathf.Clamp(this.rotateSpeed * Time.deltaTime, 0.1f, 0.9f);
                myTransform.rotation = Quaternion.Lerp(myTransform.rotation, targetRotation, rotateSpeed);
                return;
            }

            if (!playerControls.isMoving)
            {
                return;
            }

            targetRotation = Quaternion.LookRotation(playerControls.GetTargetDirection());
            rotateSpeed = Mathf.Clamp(this.rotateSpeed * Time.deltaTime, 0.1f, 0.9f);
            myTransform.rotation = Quaternion.Lerp(myTransform.rotation, targetRotation, rotateSpeed);
        }

        private void HandleLockOnMovement()
        {
            if (playerControls.dodgeFlag)
            {
                myTransform.LookAt(myTransform.position + playerControls.GetTargetDirection());
                animatorHandler.PlayAnimation("Sword1h_Dodge_Fwd", true);
                return;
            }

            myTransform.position += playerControls.GetTargetDirection() * lockWalkSpeed * Time.deltaTime;
            // Set animation state
            animatorHandler.SetState(AnimatorHandler.LOCKING_WALK);
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
