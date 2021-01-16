using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class PlayerDetector : MonoBehaviour
    {
        public Transform player;

        private Transform myTransform;

        private void Awake()
        {
            myTransform = transform;
        }

        public float GetDistanceToPlayer()
        {
            return Vector3.Distance(myTransform.position, player.position);
        }
    }
}
