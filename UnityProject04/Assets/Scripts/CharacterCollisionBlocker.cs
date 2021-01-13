using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class CharacterCollisionBlocker : MonoBehaviour
    {
        public Collider characterCollider;
        public Collider blockerCollider;

        private void Start()
        {
            Physics.IgnoreCollision(characterCollider, blockerCollider);
        }
    }
}
