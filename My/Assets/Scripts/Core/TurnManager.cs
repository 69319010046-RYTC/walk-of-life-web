using System;
using System.Collections.Generic;
using UnityEngine;
using WalkOfLife.Player;
using WalkOfLife.AI;

namespace WalkOfLife.Core
{
    public class TurnManager : MonoBehaviour
    {
        public static TurnManager Instance { get; private set; }

        public int currentRound = 1;
        public int maxRounds = 30;
        public int activePlayerIndex = 0;

        public List<PlayerController> allPlayers = new List<PlayerController>();

        public event Action<int, int> OnRoundChanged;
        public event Action<PlayerController> OnTurnStarted;
        public event Action OnGameEnded;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void StartGame(List<PlayerController> players)
        {
            allPlayers = players;
            currentRound = 1;
            activePlayerIndex = 0;
            StartCurrentTurn();
        }

        public PlayerController GetActivePlayer()
        {
            if (allPlayers.Count == 0) return null;
            return allPlayers[activePlayerIndex];
        }

        public void StartCurrentTurn()
        {
            PlayerController activePlayer = GetActivePlayer();
            activePlayer.Stats.ResetForNewTurn();

            OnRoundChanged?.Invoke(currentRound, maxRounds);
            OnTurnStarted?.Invoke(activePlayer);

            if (activePlayer.Stats.isAI)
            {
                AIBotController botAI = activePlayer.GetComponent<AIBotController>();
                if (botAI == null) botAI = activePlayer.gameObject.AddComponent<AIBotController>();
                botAI.TakeTurn(activePlayer, currentRound, maxRounds, EndCurrentTurn);
            }
        }

        public void EndCurrentTurn()
        {
            activePlayerIndex++;
            if (activePlayerIndex >= allPlayers.Count)
            {
                activePlayerIndex = 0;
                currentRound++;

                // Trigger Round Event
                Events.EventManager.Instance?.TriggerRandomEvent(allPlayers);

                if (currentRound > maxRounds)
                {
                    OnGameEnded?.Invoke();
                    return;
                }
            }

            StartCurrentTurn();
        }
    }
}
