using System.Collections.Generic;
using UnityEngine;
using WalkOfLife.Player;

namespace WalkOfLife.Events
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance { get; private set; }

        public List<EventCard> eventPool = new List<EventCard>();

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);

            InitializeEventPool();
        }

        private void InitializeEventPool()
        {
            eventPool.Add(new EventCard("Tax Refund", "You received a surprising tax refund bonus from the government!", 150f, 0f, 15f));
            eventPool.Add(new EventCard("Unexpected Sick Leave", "Caught a sudden flu, paying for medication and resting.", -80f, -15f, -10f));
            eventPool.Add(new EventCard("Crypto Boom", "Your small crypto investment surged overnight!", 300f, 0f, 20f));
            eventPool.Add(new EventCard("Appliance Repair", "Your water heater broke down and needed immediate fixing.", -120f, 0f, -15f));
            eventPool.Add(new EventCard("Lottery Ticket Winner", "You won a minor tier in the weekly city lottery!", 500f, 0f, 30f));
        }

        public EventCard TriggerRandomEvent(List<PlayerController> players)
        {
            if (eventPool.Count == 0) return null;

            EventCard drawn = eventPool[Random.Range(0, eventPool.Count)];
            foreach (var p in players)
            {
                p.Stats.ModifyCash(drawn.cashEffect);
                p.Stats.ModifyHealth(drawn.healthEffect);
                p.Stats.ModifyHappiness(drawn.happinessEffect);
            }
            Debug.Log($"[EVENT] {drawn.eventName}: {drawn.description}");
            return drawn;
        }
    }
}
