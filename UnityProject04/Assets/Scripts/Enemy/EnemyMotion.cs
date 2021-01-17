using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class EnemyMotion : MonoBehaviour
    {
        public float walkSpeed = 2.5f;
        public float rotateSpeed = 10f;
        public float lockingWalkSpeed = 1.8f;

        public Transform myTransform;
        private AnimatorHandler animatorHandler;

        private void Awake()
        {
            myTransform = transform;
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }

        public void Idle()
        {
            animatorHandler.SetState(AnimatorHandler.IDLE);
        }

        public void Walk(Vector3 targetDirection)
        {
            if (animatorHandler.GetIsInteracting())
            {
                return;
            }

            Rotate(targetDirection);
            myTransform.position += myTransform.forward * walkSpeed * Time.deltaTime;
            animatorHandler.SetState(AnimatorHandler.WALK);
        }

        public void Rotate(Vector3 targetDirection)
        {
            if (animatorHandler.GetIsInteracting() || !animatorHandler.GetCanRotate())
            {
                return;
            }

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            float rotateSpeed = Mathf.Clamp(this.rotateSpeed * Time.deltaTime, 0.1f, 0.9f);
            myTransform.rotation = Quaternion.Lerp(myTransform.rotation, targetRotation, rotateSpeed);
        }

        public void LockingWalk(Vector3 walkDirection, Vector3 targetPosition)
        {
            if (animatorHandler.GetIsInteracting())
            {
                return;
            }

            myTransform.LookAt(targetPosition);

            walkDirection.Normalize();
            myTransform.position += walkDirection * lockingWalkSpeed * Time.deltaTime;

            float inputAngle = Vector3.SignedAngle(walkDirection, myTransform.forward, Vector3.up);
            animatorHandler.SetInputAngle(inputAngle);

            animatorHandler.SetState(AnimatorHandler.LOCKING_WALK);
        }

        public void Dodge(Vector3 targetDirection)
        {
            if (animatorHandler.GetIsInteracting())
            {
                return;
            }

            myTransform.LookAt(myTransform.position + targetDirection);
            animatorHandler.PlayAnimation("Dodge", true);
        }
    }
}
