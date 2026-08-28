using System;
using UnityEngine;

namespace WalkOfLife.Player
{
    [System.Serializable]
    public class PlayerStats
    {
        public string playerName = "Player";
        public bool isAI = false;

        [Header("Resources")]
        public float cash = 500f;
        public float health = 100f;       // 0 to 100
        public float happiness = 80f;     // 0 to 100
        public float energy = 100f;       // Action points / energy per turn (max 100)
        public float hunger = 20f;        // 0 (full) to 100 (starving)
        
        [Header("Career & Education")]
        public int educationLevel = 0;    // 0: High School, 1: Bachelor, 2: Master, 3: Doctorate
        public string currentJobTitle = "Unemployed";
        public float jobSalary = 0f;

        [Header("Apartment & Assets")]
        public float furnitureValue = 0f;
        public int itemsPurchased = 0;

        [Header("Scoring")]
        public int victoryPoints = 0;

        public event Action OnStatsChanged;

        public PlayerStats(string name, bool ai = false)
        {
            this.playerName = name;
            this.isAI = ai;
            ResetForNewTurn();
        }

        public void ResetForNewTurn()
        {
            energy = 100f;
            // Starvation penalty if hunger is high
            if (hunger >= 80f)
            {
                health = Mathf.Max(10f, health - 15f);
                happiness = Mathf.Max(10f, happiness - 10f);
            }
            // Small natural hunger increase
            hunger = Mathf.Min(100f, hunger + 15f);
            
            OnStatsChanged?.Invoke();
        }

        public void ModifyCash(float amount)
        {
            cash = Mathf.Max(0f, cash + amount);
            OnStatsChanged?.Invoke();
        }

        public void ModifyHealth(float amount)
        {
            health = Mathf.Clamp(health + amount, 0f, 100f);
            OnStatsChanged?.Invoke();
        }

        public void ModifyHappiness(float amount)
        {
            happiness = Mathf.Clamp(happiness + amount, 0f, 100f);
            OnStatsChanged?.Invoke();
        }

        public void ModifyEnergy(float amount)
        {
            energy = Mathf.Clamp(energy + amount, 0f, 100f);
            OnStatsChanged?.Invoke();
        }

        public void ModifyHunger(float amount)
        {
            hunger = Mathf.Clamp(hunger + amount, 0f, 100f);
            OnStatsChanged?.Invoke();
        }

        public void AddFurniture(float value)
        {
            furnitureValue += value;
            itemsPurchased++;
            OnStatsChanged?.Invoke();
        }

        public int CalculateVictoryPoints()
        {
            float pointsFromCash = cash / 100f;
            float pointsFromEdu = educationLevel * 150f;
            float pointsFromHappiness = happiness * 2f;
            float pointsFromFurniture = furnitureValue * 1.5f;
            float healthPenalty = (100f - health) * 1.5f;

            victoryPoints = Mathf.Max(0, Mathf.RoundToInt(pointsFromCash + pointsFromEdu + pointsFromHappiness + pointsFromFurniture - healthPenalty));
            return victoryPoints;
        }
    }
}
