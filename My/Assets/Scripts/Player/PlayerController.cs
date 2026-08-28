using UnityEngine;

namespace WalkOfLife.Player
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerStats Stats { get; private set; }

        public void Initialize(string name, bool isAI)
        {
            Stats = new PlayerStats(name, isAI);
            CareerManager.Instance?.PromoteJob(Stats);
        }

        public bool CanPerformAction(float energyCost, float cashCost = 0f)
        {
            return Stats.energy >= energyCost && Stats.cash >= cashCost;
        }

        public bool Work()
        {
            JobDefinition job = CareerManager.Instance.GetJobForPlayer(Stats);
            if (!CanPerformAction(job.energyCost)) return false;

            Stats.ModifyEnergy(-job.energyCost);
            Stats.ModifyCash(job.payPerShift);
            Stats.ModifyHappiness(-job.stressCost);
            Stats.ModifyHunger(10f);
            
            Debug.Log($"{Stats.playerName} worked as {job.title} and earned ${job.payPerShift}");
            return true;
        }

        public bool Study(float tuitionCost = 300f, float energyCost = 35f)
        {
            if (!CanPerformAction(energyCost, tuitionCost)) return false;

            Stats.ModifyEnergy(-energyCost);
            Stats.ModifyCash(-tuitionCost);
            Stats.educationLevel = Mathf.Min(3, Stats.educationLevel + 1);
            Stats.ModifyHappiness(5f);

            CareerManager.Instance.PromoteJob(Stats);
            Debug.Log($"{Stats.playerName} graduated! Education Level is now {Stats.educationLevel}");
            return true;
        }

        public bool EatMeal(float mealCost = 30f, float energyCost = 10f)
        {
            if (!CanPerformAction(energyCost, mealCost)) return false;

            Stats.ModifyEnergy(-energyCost);
            Stats.ModifyCash(-mealCost);
            Stats.ModifyHunger(-40f);
            Stats.ModifyHealth(10f);
            Stats.ModifyHappiness(5f);

            Debug.Log($"{Stats.playerName} enjoyed a good meal!");
            return true;
        }

        public bool Rest(float energyGain = 40f)
        {
            Stats.ModifyEnergy(energyGain);
            Stats.ModifyHealth(15f);
            Stats.ModifyHappiness(10f);

            Debug.Log($"{Stats.playerName} took a relaxing break.");
            return true;
        }

        public bool BuyFurniture(string itemName, float cost, float vpValue)
        {
            if (!CanPerformAction(10f, cost)) return false;

            Stats.ModifyEnergy(-10f);
            Stats.ModifyCash(-cost);
            Stats.AddFurniture(vpValue);
            Stats.ModifyHappiness(15f);

            Debug.Log($"{Stats.playerName} purchased {itemName}!");
            return true;
        }
    }
}
