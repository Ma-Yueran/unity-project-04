using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR {
    public class PlayerAttacker : MonoBehaviour
    {
        private PlayerControls playerControls;
        private AnimatorHandler animatorHandler;

        private void Awake()
        {
            playerControls = GetComponent<PlayerControls>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
        }

        public void HandleAttack()
        {
            if (playerControls.comboFlag)
            {
                animatorHandler.SetBool("DoCombo", true);
            }

            if (animatorHandler.GetIsInteracting())
            {
                return;
            }

            if (playerControls.attackFlag)
            {
                animatorHandler.PlayAnimation("Light_Attack_01", true);
            }
        }
    }
}
