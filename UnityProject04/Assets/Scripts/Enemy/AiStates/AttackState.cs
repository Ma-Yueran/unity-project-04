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
                int comboNum = Random.Range(0, 3);
                enemyAttacker.Attack(comboNum);
                isAnimationPlayed = true;
            }
            else
            {
                isAnimationPlayed = false;

                int nextDecision = Random.Range(0, 11);

                if (nextDecision <= 3)
                {
                    return typeof(RetreatState);
                }
                else if (nextDecision <= 6)
                {
                    return typeof(DodgeState);
                }
                else
                {
                    return typeof(IdleState);
                }
            }

            return null;
        }
    }
}
