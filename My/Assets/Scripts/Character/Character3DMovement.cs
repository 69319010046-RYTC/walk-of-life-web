using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WalkOfLife.Map3D;
using WalkOfLife.Player;

namespace WalkOfLife.Character
{
    public class Character3DMovement : MonoBehaviour
    {
        public float moveSpeed = 5.0f;
        public Animator characterAnimator;

        public PlayerStats Stats { get; private set; }
        public CharacterRoleData RoleData { get; private set; }
        public bool isHospitalized = false;
        public bool isMoving { get; private set; } = false;

        public void Initialize(string name, CharacterRole role, bool isAI)
        {
            Stats = new PlayerStats(name, isAI);
            RoleData = new CharacterRoleData(role);
        }

        public void MoveAlongWaypoints(List<MapWaypointNode> path, System.Action onArrival = null)
        {
            if (path == null || path.Count == 0) return;
            StartCoroutine(FollowPathRoutine(path, onArrival));
        }

        private IEnumerator FollowPathRoutine(List<MapWaypointNode> path, System.Action onArrival)
        {
            isMoving = true;
            if (characterAnimator != null) characterAnimator.SetBool("IsWalking", true);

            foreach (var node in path)
            {
                Vector3 targetPos = node.transform.position;
                while (Vector3.Distance(transform.position, targetPos) > 0.05f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                    transform.LookAt(targetPos);
                    yield return null;
                }
                transform.position = targetPos;
                Core.SoundBGMManager.Instance?.PlayStepSFX();
            }

            if (characterAnimator != null) characterAnimator.SetBool("IsWalking", false);
            isMoving = false;
            onArrival?.Invoke();
        }
    }
}
