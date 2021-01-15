using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class ParryHandler : MonoBehaviour
    {
        private AnimatorHandler animatorHandler;

        private void Awake()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }

        public void Parry(string parryAnimation, Transform enemyTransform)
        {
            animatorHandler.PlayAnimation(parryAnimation, true);
            transform.LookAt(enemyTransform);
        }

        public void Parried(string parriedAnimation)
        {
            animatorHandler.PlayAnimation(parriedAnimation, true);
        }
    }
}
