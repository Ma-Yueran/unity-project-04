using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class DodgeState : BaseState
    {
        private AnimatorHandler animatorHandler;
        private EnemyMotion enemyMotion;

        private bool isAnimationPlayed;

        public DodgeState(AnimatorHandler animatorHandler, EnemyMotion enemyMotion)
        {
            this.animatorHandler = animatorHandler;
            this.enemyMotion = enemyMotion;
        }

        public override Type Tick()
        {
            if (animatorHandler.GetIsInteracting())
            {
                return null;
            }

            if (!isAnimationPlayed)
            {
                isAnimationPlayed = true;
                enemyMotion.Dodge(enemyMotion.myTransform.position - enemyMotion.myTransform.forward);
            }
            else
            {
                isAnimationPlayed = false;
                return typeof(ApproachState);
            }

            return null;
        }
    }
}
