using System.Collections;
using UnityEngine;

namespace WalkOfLife.Map3D
{
    public class Camera3DTracker : MonoBehaviour
    {
        public static Camera3DTracker Instance { get; private set; }

        public Vector3 offset = new Vector3(0, 15, -12);
        public float smoothSpeed = 4.0f;
        public Transform targetFocus;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void SetTarget(Transform newTarget)
        {
            targetFocus = newTarget;
        }

        private void LateUpdate()
        {
            if (targetFocus == null) return;

            Vector3 desiredPosition = targetFocus.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.LookAt(targetFocus.position);
        }
    }
}
