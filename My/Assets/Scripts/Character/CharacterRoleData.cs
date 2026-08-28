using UnityEngine;

namespace WalkOfLife.Character
{
    public enum CharacterRole
    {
        Workaholic, // +15% Salary
        Scholar,    // -20% Tuition
        Scavenger,  // -30% Meal Cost
        Hedonist    // +25% Fun/Happiness Gain
    }

    [System.Serializable]
    public class CharacterRoleData
    {
        public CharacterRole roleType;
        public string roleName;
        public string perkDescription;
        public float payMultiplier = 1.0f;
        public float tuitionMultiplier = 1.0f;
        public float mealCostMultiplier = 1.0f;
        public float funGainMultiplier = 1.0f;

        public CharacterRoleData(CharacterRole role)
        {
            roleType = role;
            switch (role)
            {
                case CharacterRole.Workaholic:
                    roleName = "Workaholic";
                    perkDescription = "Earn +15% higher salary from all jobs.";
                    payMultiplier = 1.15f;
                    break;
                case CharacterRole.Scholar:
                    roleName = "Scholar";
                    perkDescription = "Receive a -20% tuition discount at University.";
                    tuitionMultiplier = 0.8f;
                    break;
                case CharacterRole.Scavenger:
                    roleName = "Scavenger";
                    perkDescription = "Save -30% on all meals and groceries.";
                    mealCostMultiplier = 0.7f;
                    break;
                case CharacterRole.Hedonist:
                    roleName = "Hedonist";
                    perkDescription = "Gain +25% more Happiness/Fun from activities.";
                    funGainMultiplier = 1.25f;
                    break;
            }
        }
    }
}
