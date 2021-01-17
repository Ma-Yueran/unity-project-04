using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class PlayerLooker : MonoBehaviour
    {
        private EnemyMotion enemyMotion;
        private PlayerDetector playerDetector;

        private void Awake()
        {
            enemyMotion = GetComponentInParent<EnemyMotion>();
            playerDetector = GetComponentInParent<PlayerDetector>();
        }

        public void LookAtPlayer()
        {
            enemyMotion.myTransform.LookAt(playerDetector.player);
        }
    }
}
