using UnityEngine;
using WalkOfLife.Character;

namespace WalkOfLife.Core
{
    public class HospitalPenaltySystem : MonoBehaviour
    {
        public static HospitalPenaltySystem Instance { get; private set; }

        public const float criticalHealthThreshold = 15f;
        public const float hospitalFee = 200f;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public bool CheckAndApplyHospitalization(Character3DController player)
        {
            if (player == null || player.Stats == null) return false;

            if (player.Stats.health <= criticalHealthThreshold || player.Stats.hunger >= 95f)
            {
                player.Stats.ModifyCash(-hospitalFee);
                player.Stats.health = 80f; // Recovered in hospital
                player.Stats.hunger = 20f;
                player.isHospitalized = true;

                Debug.Log($"[HOSPITAL] {player.Stats.playerName} was hospitalized! Fee: ${hospitalFee}, Turn Skipped.");
                SoundBGMManager.Instance?.PlayHospitalAmbulanceSFX();
                return true;
            }

            return false;
        }
    }
}
