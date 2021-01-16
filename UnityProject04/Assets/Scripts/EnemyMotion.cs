using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class EnemyMotion : MonoBehaviour
    {
        public float walkSpeed = 2.5f;

        private Transform myTransform;
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
            if (animatorHandler.GetIsInteracting())
            {
                return;
            }

            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            myTransform.rotation = Quaternion.Lerp(myTransform.rotation, targetRotation, 0.1f);
        }
    }
}
