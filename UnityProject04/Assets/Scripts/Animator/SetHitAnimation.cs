using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class SetHitAnimation : StateMachineBehaviour
    {
        public string hitAnimation;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<WeaponSlotsManager>().SetHitAnimation(hitAnimation);
        }
    }
}
