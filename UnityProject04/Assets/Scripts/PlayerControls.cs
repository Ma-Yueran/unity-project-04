using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class PlayerControls : MonoBehaviour
    {
        public Transform playerCamera;

        public float inputH;
        public float inputV;
        public bool isMoving;

        private void Update()
        {
            inputH = Input.GetAxis("Horizontal");
            inputV = Input.GetAxis("Vertical");
            isMoving = inputH != 0 || inputV != 0;
        }

        public Vector3 GetTargetDirection()
        {
            Vector3 targetDirection = playerCamera.transform.forward * inputV;
            targetDirection += playerCamera.transform.right * inputH;
            targetDirection.y = 0;
            targetDirection.Normalize();

            return targetDirection;
        }
    }
}
