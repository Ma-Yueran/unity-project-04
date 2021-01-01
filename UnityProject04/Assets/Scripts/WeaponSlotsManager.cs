using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class WeaponSlotsManager : MonoBehaviour
    {
        public DamageCollider weaponDamageCollider;

        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void EnableWeaponDamageCollider()
        {
            weaponDamageCollider.EnableCollider();
        }

        public void DisableWeaponDamageCollider()
        {
            weaponDamageCollider.DisableCollider();
        }

        public void EnableAttackCombo()
        {
            animator.SetBool("CanCombo", true);
        }

        public void DisableAttackCombo()
        {
            animator.SetBool("CanCombo", false);
        }
    }
}
