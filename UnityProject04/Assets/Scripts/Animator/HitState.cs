using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class HitState : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<WeaponSlotsManager>().DisableWeaponDamageCollider();
        }
    }
}
