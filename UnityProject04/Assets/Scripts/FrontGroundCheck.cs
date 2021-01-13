using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class FrontGroundCheck : MonoBehaviour
    {
        public bool isFrontEmpty;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                isFrontEmpty = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                isFrontEmpty = true;
            }
        }
    }
}
