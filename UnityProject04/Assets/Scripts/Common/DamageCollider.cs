using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class DamageCollider : MonoBehaviour
    {
        public int damage = 30;
        public string targetTag;

        private ParryHandler myParryHandler;

        private new Collider collider;

        private string hitAnimation;
        private string parryAnimation;
        private string parriedAnimation;

        private void Awake()
        {
            myParryHandler = GetComponentInParent<ParryHandler>();
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

        public void SetHitAnimation(string hitAnimation)
        {
            this.hitAnimation = hitAnimation;
        }

        public void SetParryAnimation(string parryAnimation)
        {
            this.parryAnimation = parryAnimation;
        }

        public void SetParriedAnimation(string parriedAnimation)
        {
            this.parriedAnimation = parriedAnimation;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals(targetTag))
            {
                Stats stats = other.GetComponent<Stats>();

                if (stats != null)
                {
                    stats.TakeDamage(damage, hitAnimation);
                    DisableCollider();
                }
            }
            else if (other.tag.Equals("Parry Detector"))
            {
                ParryHandler parryHandler = other.GetComponentInParent<ParryHandler>();
                parryHandler.Parry(parryAnimation, myParryHandler.transform);
                myParryHandler.Parried(parriedAnimation);
                DisableCollider();
            }
        }
    }
}
