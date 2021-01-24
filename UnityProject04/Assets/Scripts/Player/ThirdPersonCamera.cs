using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MYR
{
    public class ThirdPersonCamera : MonoBehaviour
    {
        public static ThirdPersonCamera instance;

        public PlayerControls playerControls;

        public Transform target;
        public Transform cameraPivot;
        public Transform cameraTransform;

        public float distanceToCamera = 3;
        public float sensitivityX = 2;
        public float sensitivityY = 2;

        public LayerMask layerMask;

        public float smoothTime = 0.3f;

        public float maxLockDistance = 20;
        public float maxLockAngle = 50;

        private const float Y_MAX_ANGLE = 70;
        private const float Y_MIN_ANGLE = -50;
        private const float COLLISION_OFFSET = 0.2f;
        private const float MIN_DISTANCE = 0.3f;

        private float currentX;
        private float currentY;
        private float currentDistance;
        private Vector3 velocity = Vector3.zero;

        public bool isLockingOn;
        public Transform currentLockOn;
        private EnemyManager enemyManager;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(instance);
            }
        }

        private void Start()
        {
            playerControls = target.GetComponent<PlayerControls>();
            enemyManager = EnemyManager.instance;
        }

        private void Update()
        {
            currentX += Input.GetAxis("Mouse X") * sensitivityX;
            currentY -= Input.GetAxis("Mouse Y") * sensitivityY;

            currentY = Mathf.Clamp(currentY, Y_MIN_ANGLE, Y_MAX_ANGLE);

            if (isLockingOn && Vector3.Distance(target.position, currentLockOn.position) > maxLockDistance)
            {
                isLockingOn = false;
                currentLockOn = null;
            }
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
            Vector3 targetPos;

            if (isLockingOn)
            {
                Vector3 dir = new Vector3(0, 0, -currentDistance);
                Quaternion rotation = Quaternion.LookRotation(currentLockOn.position - target.position);
                targetPos = cameraPivot.position + rotation * dir + Vector3.up * 0.7f;
            }
            else
            {
                Vector3 dir = new Vector3(0, 0, -currentDistance);
                Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
                targetPos = cameraPivot.position + rotation * dir;
            }

            cameraTransform.position = Vector3.Slerp(cameraTransform.position, targetPos, 0.1f);
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

        public bool HandleLockOn()
        {
            if (playerControls.lockOnFlag)
            {
                if (isLockingOn)
                {
                    isLockingOn = false;
                    currentLockOn = null;
                }
                else
                {
                    currentLockOn = GetLockOnTarget();

                    if (currentLockOn != null)
                    {
                        isLockingOn = true;
                    }
                }
            }

            return isLockingOn;
        }

        private Transform GetLockOnTarget()
        {
            foreach (Transform enemy in enemyManager.enemies)
            {
                if (!enemy.gameObject.activeInHierarchy)
                {
                    continue;
                }

                if (Vector3.Distance(enemy.position, target.position) > maxLockDistance)
                {
                    continue;
                }

                if (Vector3.Angle(cameraTransform.forward, enemy.position - cameraTransform.position) > maxLockAngle)
                {
                    continue;
                }

                return enemy;
            }

            return null;
        }
    }
}
