using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class WeaponSlotsManager : MonoBehaviour
    {
        public DamageCollider weaponDamageCollider;

        public void EnableWeaponDamageCollider()
        {
            weaponDamageCollider.EnableCollider();
        }

        public void DisableWeaponDamageCollider()
        {
            weaponDamageCollider.DisableCollider();
        }
    }
}
