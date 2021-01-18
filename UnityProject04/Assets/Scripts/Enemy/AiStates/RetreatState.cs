using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class RetreatState : BaseState
    {
        private AnimatorHandler animatorHandler;
        private EnemyMotion enemyMotion;
        private PlayerDetector playerDetector;

        private float retreatTimer = 0;

        public RetreatState(AnimatorHandler animatorHandler, EnemyMotion enemyMotion, PlayerDetector playerDetector)
        {
            this.animatorHandler = animatorHandler;
            this.enemyMotion = enemyMotion;
            this.playerDetector = playerDetector;
        }

        public override System.Type Tick()
        {
            if (animatorHandler.GetIsInteracting())
            {
                return null;
            }

            if (retreatTimer == 0)
            {
                retreatTimer = Time.time + Random.Range(1f, 2f);
            }
            else if (Time.time < retreatTimer)
            {
                enemyMotion.LockingWalk(-enemyMotion.myTransform.forward, playerDetector.player.position);
            }
            else
            {
                retreatTimer = 0;
                return typeof(ApproachState);
            }

            return null;
        }
    }
}
