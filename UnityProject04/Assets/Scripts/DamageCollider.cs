using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class DamageCollider : MonoBehaviour
    {
        public int damage = 30;

        private new Collider collider;

        private void Awake()
        {
            collider = GetComponent<Collider>();
            DisableCollider();
        }

        public void EnableCollider()
        {
            collider.enabled = true;
        }

        public void DisableCollider()
        {
            collider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Enemy"))
            {
                Stats stats = other.GetComponent<Stats>();

                if (stats != null)
                {
                    stats.TakeDamage(damage);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag.Equals("Enemy"))
            {
                DisableCollider();
            }
        }
    }
}
