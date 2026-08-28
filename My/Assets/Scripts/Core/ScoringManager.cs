using System.Collections.Generic;
using UnityEngine;
using WalkOfLife.Player;

namespace WalkOfLife.Core
{
    public class ScoringManager : MonoBehaviour
    {
        public static ScoringManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public PlayerController DetermineWinner(List<PlayerController> players)
        {
            PlayerController winner = null;
            int highestVP = -1;

            foreach (var p in players)
            {
                int vp = p.Stats.CalculateVictoryPoints();
                Debug.Log($"{p.Stats.playerName} Final Score: {vp} VP (Cash:${p.Stats.cash}, Edu:{p.Stats.educationLevel}, Furniture:${p.Stats.furnitureValue})");

                if (vp > highestVP)
                {
                    highestVP = vp;
                    winner = p;
                }
            }

            return winner;
        }
    }
}
