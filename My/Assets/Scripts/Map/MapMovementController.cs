using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WalkOfLife.Map
{
    public class MapMovementController : MonoBehaviour
    {
        public float moveSpeed = 4.0f;
        public bool isMoving { get; private set; } = false;

        public void MoveToNode(MapNode targetNode, System.Action onArrival = null)
        {
            if (targetNode == null) return;
            StartCoroutine(MoveRoutine(targetNode.transform.position, onArrival));
        }

        private IEnumerator MoveRoutine(Vector3 targetPosition, System.Action onArrival)
        {
            isMoving = true;
            while (Vector3.Distance(transform.position, targetPosition) > 0.05f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
            transform.position = targetPosition;
            isMoving = false;
            onArrival?.Invoke();
        }
    }
}
