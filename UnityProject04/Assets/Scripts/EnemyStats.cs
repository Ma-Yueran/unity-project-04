using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class EnemyStats : Stats
    {
        public int maxHealth = 100;
        public int currentHealth;

        private AnimatorHandler animatorHandler;

        private void Awake()
        {
            currentHealth = maxHealth;
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }

        public override void TakeDamage(int amount)
        {
            currentHealth -= amount;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayAnimation("Death", true);
            }
            else
            {
                animatorHandler.PlayAnimation("Hit", true);
            }
        }
    }
}
