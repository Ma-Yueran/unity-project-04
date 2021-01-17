using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class ChaseState : BaseState
    {
        private EnemyMotion enemyMotion;
        private PlayerDetector playerDetector;

        public ChaseState(EnemyMotion enemyMotion, PlayerDetector playerDetector)
        {
            this.enemyMotion = enemyMotion;
            this.playerDetector = playerDetector;
        }

        public override System.Type Tick()
        {
            if (playerDetector.GetDistanceToPlayer() > 2)
            {
                Vector3 targetDirection = playerDetector.GetDirectionToPlayer();
                targetDirection.y = 0;
                enemyMotion.Walk(targetDirection);

                return null;
            }
            else
            {
                enemyMotion.Idle();
                return null;
            }
        }
    }
}
