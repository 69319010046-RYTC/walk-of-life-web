using System.Collections.Generic;
using UnityEngine;
using WalkOfLife.Player;
using WalkOfLife.UI;

namespace WalkOfLife.Core
{
    public enum GameState
    {
        MainMenu,
        Playing,
        GameOver
    }

    public class GameStateManager : MonoBehaviour
    {
        public static GameStateManager Instance { get; private set; }

        public GameState CurrentState { get; private set; } = GameState.MainMenu;

        [Header("Prefabs & References")]
        public GameObject playerPrefab;

        public List<PlayerController> players = new List<PlayerController>();

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        private void Start()
        {
            SetupNewGame(numBots: 3);
        }

        public void SetupNewGame(int numBots = 3)
        {
            players.Clear();

            // Create Human Player
            GameObject humanObj = new GameObject("HumanPlayer");
            PlayerController humanController = humanObj.AddComponent<PlayerController>();
            humanController.Initialize("You (Player 1)", isAI: false);
            players.Add(humanController);

            // Create AI Bots
            for (int i = 1; i <= numBots; i++)
            {
                GameObject botObj = new GameObject($"AIBot_{i}");
                PlayerController botController = botObj.AddComponent<PlayerController>();
                botController.Initialize($"Bot {i}", isAI: true);
                botObj.AddComponent<AI.AIBotController>();
                players.Add(botController);
            }

            CurrentState = GameState.Playing;
            TurnManager.Instance?.StartGame(players);
        }
    }
}
