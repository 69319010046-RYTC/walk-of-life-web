using UnityEngine;
using UnityEngine.UI;
using WalkOfLife.Player;
using WalkOfLife.Core;

namespace WalkOfLife.UI
{
    public class HUDController : MonoBehaviour
    {
        [Header("UI References")]
        public Text playerNameText;
        public Text roundText;
        public Text cashText;
        public Text jobTitleText;
        public Text victoryPointsText;

        public Slider healthSlider;
        public Slider happinessSlider;
        public Slider energySlider;
        public Slider hungerSlider;

        public Button workButton;
        public Button studyButton;
        public Button eatButton;
        public Button restButton;
        public Button buyFurnitureButton;
        public Button endTurnButton;

        private PlayerController activePlayer;

        private void Start()
        {
            if (TurnManager.Instance != null)
            {
                TurnManager.Instance.OnTurnStarted += OnTurnStarted;
                TurnManager.Instance.OnRoundChanged += OnRoundChanged;
            }

            SetupButtonListeners();
        }

        private void OnDestroy()
        {
            if (TurnManager.Instance != null)
            {
                TurnManager.Instance.OnTurnStarted -= OnTurnStarted;
                TurnManager.Instance.OnRoundChanged -= OnRoundChanged;
            }
        }

        private void SetupButtonListeners()
        {
            workButton?.onClick.AddListener(() => { activePlayer?.Work(); UpdateUI(); });
            studyButton?.onClick.AddListener(() => { activePlayer?.Study(); UpdateUI(); });
            eatButton?.onClick.AddListener(() => { activePlayer?.EatMeal(); UpdateUI(); });
            restButton?.onClick.AddListener(() => { activePlayer?.Rest(); UpdateUI(); });
            buyFurnitureButton?.onClick.AddListener(() => { activePlayer?.BuyFurniture("Sofa", 200f, 120f); UpdateUI(); });
            endTurnButton?.onClick.AddListener(() => { TurnManager.Instance?.EndCurrentTurn(); });
        }

        private void OnRoundChanged(int round, int maxRounds)
        {
            if (roundText != null) roundText.text = $"Round: {round} / {maxRounds}";
        }

        private void OnTurnStarted(PlayerController player)
        {
            activePlayer = player;
            if (activePlayer != null)
            {
                activePlayer.Stats.OnStatsChanged += UpdateUI;
            }
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (activePlayer == null || activePlayer.Stats == null) return;

            PlayerStats stats = activePlayer.Stats;

            if (playerNameText != null) playerNameText.text = stats.playerName + (stats.isAI ? " [BOT]" : "");
            if (cashText != null) cashText.text = $"${stats.cash:F0}";
            if (jobTitleText != null) jobTitleText.text = $"Job: {stats.currentJobTitle} (Edu Lv.{stats.educationLevel})";
            if (victoryPointsText != null) victoryPointsText.text = $"VP: {stats.CalculateVictoryPoints()}";

            if (healthSlider != null) healthSlider.value = stats.health / 100f;
            if (happinessSlider != null) happinessSlider.value = stats.happiness / 100f;
            if (energySlider != null) energySlider.value = stats.energy / 100f;
            if (hungerSlider != null) hungerSlider.value = stats.hunger / 100f;

            bool isHumanTurn = !stats.isAI;
            SetActionButtonsInteractable(isHumanTurn && stats.energy >= 10f);
        }

        private void SetActionButtonsInteractable(bool interactable)
        {
            if (workButton != null) workButton.interactable = interactable;
            if (studyButton != null) studyButton.interactable = interactable;
            if (eatButton != null) eatButton.interactable = interactable;
            if (restButton != null) restButton.interactable = interactable;
            if (buyFurnitureButton != null) buyFurnitureButton.interactable = interactable;
            if (endTurnButton != null) endTurnButton.interactable = interactable;
        }
    }
}
