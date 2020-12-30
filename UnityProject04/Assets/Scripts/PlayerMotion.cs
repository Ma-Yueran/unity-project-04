using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class PlayerMotion : MonoBehaviour
    {
        public float speed = 3;

        private Transform myTransform;
        private PlayerControls playerControls;

        private void Awake()
        {
            myTransform = transform;
            playerControls = GetComponent<PlayerControls>();
        }

        private void Update()
        {
            HandleMovement();
            HandleRotation();
        }

        private void HandleMovement()
        {
            if (!playerControls.isMoving)
            {
                return;
            }

            myTransform.position += playerControls.GetTargetDirection() * speed * Time.deltaTime;
        }

        private void HandleRotation()
        {
            if (!playerControls.isMoving)
            {
                return;
            }

            Quaternion targetDirection = Quaternion.LookRotation(playerControls.GetTargetDirection());
            myTransform.rotation = Quaternion.Lerp(myTransform.rotation, targetDirection, 0.1f);
        }
    }
}
