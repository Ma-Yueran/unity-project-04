using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class AttackState : BaseState
    {
        private AnimatorHandler animatorHandler;
        private EnemyAttacker enemyAttacker;

        private bool isAnimationPlayed = false;

        public AttackState(AnimatorHandler animatorHandler, EnemyAttacker enemyAttacker)
        {
            this.animatorHandler = animatorHandler;
            this.enemyAttacker = enemyAttacker;
        }

        public override System.Type Tick()
        {
            if (animatorHandler.GetIsInteracting())
            {
                return null;
            }

            if (!isAnimationPlayed)
            {
                int comboNum = Random.Range(0, 2);
                enemyAttacker.Attack(comboNum);
                isAnimationPlayed = true;
            }
            else
            {
                isAnimationPlayed = false;
                return typeof(ApproachState);
            }

            return null;
        }
    }
}
