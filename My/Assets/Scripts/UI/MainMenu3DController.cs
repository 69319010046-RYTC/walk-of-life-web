using UnityEngine;
using UnityEngine.UI;
using WalkOfLife.Core;

namespace WalkOfLife.UI
{
    public class MainMenu3DController : MonoBehaviour
    {
        [Header("UI Panels")]
        public GameObject mainMenuPanel;
        public GameObject characterSelectPanel;

        [Header("Options")]
        public Dropdown roundSelectDropdown; // 20 or 30 Rounds
        public Dropdown botCountDropdown;   // 1, 2, or 3 Bots

        public Button startGameButton;

        private int selectedRoleIndex = 0;

        private void Start()
        {
            if (mainMenuPanel != null) mainMenuPanel.SetActive(true);
            if (startGameButton != null) startGameButton.onClick.AddListener(OnStartGameClicked);
        }

        public void SelectCharacterRole(int roleIndex)
        {
            selectedRoleIndex = roleIndex;
            Debug.Log($"Selected Role: {roleIndex}");
        }

        private void OnStartGameClicked()
        {
            int rounds = roundSelectDropdown != null && roundSelectDropdown.value == 1 ? 30 : 20;
            int bots = botCountDropdown != null ? botCountDropdown.value + 1 : 3;

            Debug.Log($"[MAIN MENU] Starting Game: {rounds} Rounds, {bots} AI Bots, Role: {selectedRoleIndex}");
            
            if (mainMenuPanel != null) mainMenuPanel.SetActive(false);
            
            GameStateManager.Instance?.SetupNewGame(bots);
        }
    }
}
