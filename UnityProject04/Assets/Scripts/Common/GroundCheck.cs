using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class GroundCheck : MonoBehaviour
    {
        public float minDistanceToFall = 2;
        public float landingDistance = 1;
        public bool isGrounded;

        public bool IsGoingToFall()
        {
            if (isGrounded)
            {
                return false;
            }

            if (Physics.Raycast(transform.position, Vector3.down, minDistanceToFall))
            {
                return false;
            }

            return true;
        }

        public bool IsLanding()
        {
            if (isGrounded)
            {
                return true;
            }

            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit, landingDistance))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    return true;
                }
            }

            return false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                isGrounded = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Ground"))
            {
                isGrounded = false;
            }
        }
    }
}
