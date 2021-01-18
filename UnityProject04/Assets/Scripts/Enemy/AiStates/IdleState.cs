using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class IdleState : BaseState
    {
        private AnimatorHandler animatorHandler;
        private EnemyMotion enemyMotion;
        private PlayerDetector playerDetector;

        private float standTimer = 0;

        public IdleState(AnimatorHandler animatorHandler, EnemyMotion enemyMotion, PlayerDetector playerDetector)
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

            if (standTimer == 0)
            {
                standTimer = Time.time + Random.Range(1f, 2f);
            }
            else if (Time.time < standTimer)
            {
                if (playerDetector.GetDistanceToPlayer() < 10)
                {
                    enemyMotion.LookAt(playerDetector.player.position);
                }

                enemyMotion.Idle();
            }
            else
            {
                standTimer = 0;
                return typeof(ApproachState);
            }

            return null;
        }
    }
}
