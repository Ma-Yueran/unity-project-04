using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    /// <summary>
    /// PlayerControls provides input information from the player.
    /// </summary>
    public class PlayerControls : MonoBehaviour
    {
        public Transform playerCamera;

        public float inputH;
        public float inputV;
        public bool isMoving;
        public bool isRunning;

        [Header("Flags")]
        public bool dodgeFlag;
        public bool attackFlag01;
        public bool attackFlag02;
        public bool comboFlag;
        public bool lockOnFlag;

        private float keyDownTime;
        private float keyReactionTime = 0.3f;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        public Vector3 GetTargetDirection()
        {
            Vector3 targetDirection = playerCamera.transform.forward * inputV;
            targetDirection += playerCamera.transform.right * inputH;
            targetDirection.y = 0;
            targetDirection.Normalize();

            return targetDirection;
        }

        public void HandlePlayerInputs()
        {
            inputH = Input.GetAxis("Horizontal");
            inputV = Input.GetAxis("Vertical");
            isMoving = inputH != 0 || inputV != 0;

            animator.SetFloat("InputH", inputH);
            animator.SetFloat("InputV", inputV);

            HandleDodgeAndRunInput();
            HandleAttackAndComboInput();
            HandleLockOnInput();
        }

        public void ResetFlags()
        {
            dodgeFlag = false;
            attackFlag01 = false;
            attackFlag02 = false;
            comboFlag = false;
            lockOnFlag = false;
        }

        private void HandleDodgeAndRunInput()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                keyDownTime = Time.time;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if (Time.time - keyDownTime < keyReactionTime)
                {
                    dodgeFlag = true;
                }
            }

            isRunning = Input.GetKey(KeyCode.LeftShift);
        }

        private void HandleAttackAndComboInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (animator.GetBool("CanCombo") && !animator.GetBool("DoCombo"))
                {
                    comboFlag = true;
                }
                else
                {
                    attackFlag01 = true;
                }
            }
           
            if (Input.GetMouseButtonDown(1))
            {
                attackFlag02 = true;
            }
        }

        private void HandleLockOnInput()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                lockOnFlag = true;
            }
        }
    }
}
