using System.Collections.Generic;
using UnityEngine;

namespace WalkOfLife.Core
{
    [System.Serializable]
    public class RiskRewardCard
    {
        public string title;
        public string description;
        public string safeOptionText;
        public float safeCost;
        public string gambleOptionText;
        public float gambleSuccessRate; // e.g. 0.5 = 50%
        public float gambleSuccessCash;
        public float gambleFailPenalty;

        public RiskRewardCard(string t, string d, string safeT, float safeC, string gambleT, float rate, float winC, float failP)
        {
            title = t; description = d; safeOptionText = safeT; safeCost = safeC;
            gambleOptionText = gambleT; gambleSuccessRate = rate; gambleSuccessCash = winC; gambleFailPenalty = failP;
        }
    }

    public class RiskRewardEvents : MonoBehaviour
    {
        public static RiskRewardEvents Instance { get; private set; }

        public List<RiskRewardCard> eventCardsPool = new List<RiskRewardCard>();

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);

            InitializePool();
        }

        private void InitializePool()
        {
            eventCardsPool.Add(new RiskRewardCard(
                "Appliance Breakdown", "Your air conditioner broke down on a hot weekend!",
                "Hire Certified Tech ($100)", 100f,
                "Try DIY Fix (50% Chance)", 0.5f, 0f, 250f
            ));

            eventCardsPool.Add(new RiskRewardCard(
                "Crypto Market Surge", "A speculative meme coin is trending on social media!",
                "Pass & Stay Safe ($0)", 0f,
                "Invest $200 (50% Chance)", 0.5f, 500f, 200f
            ));
        }

        public void TriggerWeekendEvent()
        {
            if (eventCardsPool.Count == 0) return;
            RiskRewardCard drawn = eventCardsPool[Random.Range(0, eventCardsPool.Count)];
            Debug.Log($"[WEEKEND EVENT] Triggered: {drawn.title} - {drawn.description}");
        }
    }
}
