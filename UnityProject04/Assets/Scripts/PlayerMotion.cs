using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class PlayerMotion : MonoBehaviour
    {
        public float speed = 10;

        private Transform myTransform;
        private new Rigidbody rigidbody;
        private PlayerControls playerControls;

        private void Awake()
        {
            myTransform = transform;
            rigidbody = GetComponent<Rigidbody>();
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
                rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, Vector3.zero, 0.1f);
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
