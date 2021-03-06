﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class EnemyAttacker : MonoBehaviour
    {
        private AnimatorHandler animatorHandler;

        private void Awake()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }

        public void Attack(int comboNum)
        {
            if (animatorHandler.GetIsInteracting())
            {
                return;
            }

            animatorHandler.PlayAnimation("Attack01", true);
            animatorHandler.SetComboNum(comboNum);
        }
    }
}
