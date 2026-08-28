using UnityEngine;

namespace WalkOfLife.Events
{
    [System.Serializable]
    public class EventCard
    {
        public string eventName;
        public string description;
        public float cashEffect;
        public float healthEffect;
        public float happinessEffect;

        public EventCard(string name, string desc, float cash, float health, float happy)
        {
            this.eventName = name;
            this.description = desc;
            this.cashEffect = cash;
            this.healthEffect = health;
            this.happinessEffect = happy;
        }
    }
}
