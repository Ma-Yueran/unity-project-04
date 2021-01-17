using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class WanderState : BaseState
    {
        private EnemyMotion enemyMotion;
        private PlayerDetector playerDetector;

        private bool isWalking;
        private Vector3 walkDirection;
        private float nextUpdateTime = 0;

        public WanderState(EnemyMotion enemyMotion, PlayerDetector playerDetector)
        {
            this.enemyMotion = enemyMotion;
            this.playerDetector = playerDetector;
        }

        public override System.Type Tick()
        {
            if (playerDetector.GetDistanceToPlayer() < 8)
            {
                return typeof(ChaseState);
            }

            Wander();

            return null;
        }

        private void Wander()
        {
            if (Time.time > nextUpdateTime)
            {
                if (isWalking)
                {
                    isWalking = false;
                }
                else
                {
                    isWalking = true;
                    walkDirection = GetRandomWalkDirection();
                }

                nextUpdateTime = Time.time + Random.Range(3, 5);
            }
            else
            {
                if (isWalking)
                {
                    enemyMotion.Walk(walkDirection);
                }
                else
                {
                    enemyMotion.Idle();
                }
            }
        }

        private Vector3 GetRandomWalkDirection()
        {
            float xDir = Random.Range(-1f, 1f);
            float zDir = Random.Range(-1f, 1f);
            Vector3 dir = new Vector3(xDir, 0, zDir);

            return dir;
        }
    }
}
