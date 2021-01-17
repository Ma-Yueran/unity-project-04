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
            if (playerDetector.GetDistanceToPlayer() > 5)
            {
                Vector3 targetDirection = playerDetector.GetDirectionToPlayer();
                targetDirection.y = 0;
                enemyMotion.Walk(targetDirection);

                return null;
            }
            else
            {
                enemyMotion.LockingWalk(enemyMotion.myTransform.right, playerDetector.player.position);
                return null;
            }
        }
    }
}
