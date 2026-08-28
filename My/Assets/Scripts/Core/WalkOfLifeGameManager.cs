using System;
using System.Collections.Generic;
using UnityEngine;
using WalkOfLife.Character;
using WalkOfLife.UI;

namespace WalkOfLife.Core
{
    public enum GamePhase
    {
        MainMenu,
        BoardMap,
        InteriorScene,
        WeekendEvent,
        VictoryCeremony
    }

    public class WalkOfLifeGameManager : MonoBehaviour
    {
        public static WalkOfLifeGameManager Instance { get; private set; }

        public GamePhase CurrentPhase { get; private set; } = GamePhase.MainMenu;

        [Header("Game Configuration")]
        public int totalRounds = 20;
        public int numBots = 3;
        public CharacterRole selectedPlayerRole = CharacterRole.Workaholic;

        [Header("Players List")]
        public List<Character3DController> allPlayers = new List<Character3DController>();
        public int activePlayerIndex = 0;

        public event Action<GamePhase> OnPhaseChanged;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void StartNewGame(CharacterRole role, int rounds, int botsCount)
        {
            selectedPlayerRole = role;
            totalRounds = rounds;
            numBots = botsCount;

            Debug.Log($"[GAME MANAGER] Starting Game: Role={role}, Rounds={rounds}, Bots={botsCount}");
            SetPhase(GamePhase.BoardMap);
        }

        public void SetPhase(GamePhase nextPhase)
        {
            CurrentPhase = nextPhase;
            OnPhaseChanged?.Invoke(CurrentPhase);
            Debug.Log($"[GAME MANAGER] Switched to Phase: {nextPhase}");
        }

        public Character3DController GetActivePlayer()
        {
            if (allPlayers.Count == 0) return null;
            return allPlayers[activePlayerIndex];
        }
    }
}
