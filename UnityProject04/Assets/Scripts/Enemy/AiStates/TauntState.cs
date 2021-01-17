using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class TauntState : BaseState
    {
        private AnimatorHandler animatorHandler;

        private bool isAnimationPlayed = false;

        public TauntState(AnimatorHandler animatorHandler)
        {
            this.animatorHandler = animatorHandler;
        }

        public override Type Tick()
        {
            if (animatorHandler.GetIsInteracting())
            {
                return null;
            }

            if (!isAnimationPlayed)
            {
                animatorHandler.PlayAnimation("Taunt", true);
                isAnimationPlayed = true;
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
