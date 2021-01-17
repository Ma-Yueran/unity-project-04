using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class ApproachState : BaseState
    {
        private EnemyMotion enemyMotion;
        private PlayerDetector playerDetector;

        private float nextUpdateTime = 0;
        private Vector3 walkDirection;

        public ApproachState(EnemyMotion enemyMotion, PlayerDetector playerDetector)
        {
            this.enemyMotion = enemyMotion;
            this.playerDetector = playerDetector;
        }

        public override System.Type Tick()
        {
            if (Time.time > nextUpdateTime)
            {
                walkDirection = GetNewDirection();
                nextUpdateTime = GetNextUpdateTime();
            }
            else if (playerDetector.GetDistanceToPlayer() < 2.5f)
            {
                int nextDecision = Random.Range(0, 3);

                if (nextDecision == 0)
                {
                    return typeof(DodgeState);
                }
                else if (nextDecision == 1)
                {
                    return typeof(TauntState);
                }
                else
                {
                    return typeof(AttackState);
                }
            }
            else
            {
                enemyMotion.LockingWalk(walkDirection, playerDetector.player.position);
            }

            return null;
        }

        public Vector3 GetNewDirection()
        {
            return enemyMotion.myTransform.forward + enemyMotion.myTransform.right * Random.Range(-1f, 1f);
        }

        public float GetNextUpdateTime()
        {
            return Time.time + Random.Range(1f, 2f);
        }
    }
}
