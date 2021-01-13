using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    /// <summary>
    /// AnimatorHandler is used to set the current animation state or to play a specific animation.
    /// </summary>
    public class AnimatorHandler : MonoBehaviour
    {
        public static readonly int IDLE = 0;
        public static readonly int WALK = 1;
        public static readonly int RUN = 2;

        public int currentAnimationState = 0;

        public FrontGroundCheck frontGroundCheck;

        private Animator animator;
        private new Rigidbody rigidbody;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            rigidbody = GetComponentInParent<Rigidbody>();
        }

        public void SetState(int state)
        {
            animator.SetInteger("State", state);
            currentAnimationState = state;
        }

        public void SetBool(string boolName, bool value)
        {
            animator.SetBool(boolName, value);
        }

        public void PlayAnimation(string animationName, bool isInteracting)
        {
            animator.SetBool("IsInteracting", isInteracting);
            animator.applyRootMotion = isInteracting;
            animator.CrossFade(animationName, 0.2f);
        }

        public bool GetIsInteracting()
        {
            return animator.GetBool("IsInteracting");
        }

        public void SetIsBeingHit(bool isBeingHit)
        {
            animator.SetBool("IsBeingHit", isBeingHit);
        }

        public bool GetIsBeingHit()
        {
            return animator.GetBool("IsBeingHit");
        }

        public bool GetCanRotate()
        {
            return animator.GetBool("CanRotate");
        }

        public void EnableRotation()
        {
            animator.SetBool("CanRotate", true);
        }

        public void DisableRotation()
        {
            animator.SetBool("CanRotate", false);
        }

        public void SetIsFalling(bool isFalling)
        {
            animator.SetBool("IsFalling", isFalling);
        }

        public bool GetIsFalling()
        {
            return animator.GetBool("IsFalling");
        }

        private void OnAnimatorMove()
        {
            if (!animator.GetBool("IsInteracting") || frontGroundCheck.isFrontEmpty)
            {
                return;
            }

            rigidbody.drag = 0;
            Vector3 deltaPosition = animator.deltaPosition;
            deltaPosition.y = 0;
            Vector3 velocity = deltaPosition / Time.deltaTime;
            rigidbody.velocity = velocity;
        }
    }
}
