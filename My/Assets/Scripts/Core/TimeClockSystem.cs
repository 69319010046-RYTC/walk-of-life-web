using System;
using UnityEngine;

namespace WalkOfLife.Core
{
    public class TimeClockSystem : MonoBehaviour
    {
        public static TimeClockSystem Instance { get; private set; }

        public int currentRound = 1;
        public float currentActionHours = 12.0f; // 12 Hours per day/turn
        public const float maxActionHours = 12.0f;

        public event Action<int> OnRoundUpdated;
        public event Action<float> OnHoursUpdated;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public bool ConsumeHours(float hours)
        {
            if (currentActionHours >= hours)
            {
                currentActionHours -= hours;
                OnHoursUpdated?.Invoke(currentActionHours);
                return true;
            }
            return false;
        }

        public void ResetHoursForNewTurn()
        {
            currentActionHours = maxActionHours;
            OnHoursUpdated?.Invoke(currentActionHours);
        }

        public void AdvanceRound()
        {
            currentRound++;
            OnRoundUpdated?.Invoke(currentRound);

            if (currentRound % 5 == 0)
            {
                // Trigger Weekend Event Card every 5 rounds
                RiskRewardEvents.Instance?.TriggerWeekendEvent();
            }
        }
    }
}
