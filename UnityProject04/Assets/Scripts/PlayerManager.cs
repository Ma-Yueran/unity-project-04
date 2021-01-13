using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class PlayerManager : MonoBehaviour
    {
        private PlayerControls playerControls;
        private PlayerMotion playerMotion;
        private PlayerAttacker playerAttacker;

        private void Awake()
        {
            playerControls = GetComponent<PlayerControls>();
            playerMotion = GetComponent<PlayerMotion>();
            playerAttacker = GetComponent<PlayerAttacker>();
        }

        private void Update()
        {
            playerControls.HandlePlayerInputs();
            playerMotion.HandleMovement();
            playerMotion.HandleFalling();
            playerAttacker.HandleAttack();
        }

        private void LateUpdate()
        {
            playerControls.ResetFlags();
        }
    }
}
