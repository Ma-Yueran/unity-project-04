using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class ThirdPersonCamera : MonoBehaviour
    {
        public Transform target;
        public Transform cameraPivot;
        public Transform cameraTransform;

        public float distanceToCamera = 3;
        public float sensitivityX = 2;
        public float sensitivityY = 2;

        public LayerMask layerMask;

        public float smoothTime = 0.3f;

        private const float Y_MAX_ANGLE = 70;
        private const float Y_MIN_ANGLE = -50;
        private const float COLLISION_OFFSET = 0.2f;
        private const float MIN_DISTANCE = 0.3f;

        private float currentX;
        private float currentY;
        private float currentDistance;
        private Vector3 velocity = Vector3.zero;

        private void Update()
        {
            currentX += Input.GetAxis("Mouse X") * sensitivityX;
            currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

            currentY = Mathf.Clamp(currentY, Y_MIN_ANGLE, Y_MAX_ANGLE);
        }

        private void LateUpdate()
        {
            FollowTarget();
            HandleCameraRotation();
            HandleCameraCollision();
        }

        private void FollowTarget()
        {
            Vector3 targetPosition = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
            transform.position = targetPosition;
        }

        private void HandleCameraRotation()
        {
            Vector3 dir = new Vector3(0, 0, -currentDistance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            cameraTransform.position = cameraPivot.position + rotation * dir;
            cameraTransform.LookAt(cameraPivot);
        }

        private void HandleCameraCollision()
        {
            RaycastHit hit;

            Vector3 dir = cameraTransform.position - cameraPivot.position;

            if (Physics.Raycast(cameraPivot.position, dir, out hit, distanceToCamera, layerMask))
            {
                float dis = Vector3.Distance(hit.point, cameraPivot.position) - COLLISION_OFFSET;
                currentDistance = Mathf.Lerp(currentDistance, dis, 0.1f);

                if (currentDistance < MIN_DISTANCE)
                {
                    currentDistance = MIN_DISTANCE;
                }
            }
            else
            {
                currentDistance = Mathf.Lerp(currentDistance, distanceToCamera, 0.1f);
            }
        }
    }
}
