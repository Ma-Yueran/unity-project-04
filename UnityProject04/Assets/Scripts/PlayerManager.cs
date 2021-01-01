using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class PlayerManager : MonoBehaviour
    {
        private PlayerControls playerControls;
        private PlayerMotion playerMotion;

        private void Awake()
        {
            playerControls = GetComponent<PlayerControls>();
            playerMotion = GetComponent<PlayerMotion>();
        }

        private void Update()
        {
            playerControls.HandlePlayerInputs();
            playerMotion.HandleMovement();
        }

        private void LateUpdate()
        {
            playerControls.ResetFlags();
        }
    }
}
