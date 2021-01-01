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
        public bool isAttacking;

        [Header("Flags")]
        public bool dodgeFlag;

        private float keyDownTime;
        private float keyReactionTime = 0.3f;

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

            isAttacking = Input.GetMouseButton(0);

            HandleDodgeAndRunInput();
        }

        public void ResetFlags()
        {
            dodgeFlag = false;
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
    }
}
