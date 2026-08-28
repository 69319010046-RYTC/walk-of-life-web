using UnityEngine;
using UnityEngine.UI;
using WalkOfLife.Core;

namespace WalkOfLife.UI
{
    public class ThaiMainMenuController : MonoBehaviour
    {
        [Header("Main Menu UI Panels")]
        public GameObject mainMenuPanel;
        public GameObject lobbyPanel;
        public GameObject settingsPanel;

        [Header("Pager Room Code")]
        public Text pagerCodeText; // Displays e.g. "WGNIN9FC"
        public Button copyPagerCodeButton;
        public InputField joinRoomInputField;

        private string currentRoomCode = "WGNIN9FC";

        private void Start()
        {
            GenerateNewRoomCode();

            if (copyPagerCodeButton != null)
                copyPagerCodeButton.onClick.AddListener(CopyRoomCodeToClipboard);
        }

        public void GenerateNewRoomCode()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] stringChars = new char[8];
            for (int i = 0; i < 8; i++)
            {
                stringChars[i] = chars[UnityEngine.Random.Range(0, chars.Length)];
            }
            currentRoomCode = new string(stringChars);

            if (pagerCodeText != null)
                pagerCodeText.text = currentRoomCode;
        }

        public void CopyRoomCodeToClipboard()
        {
            GUIUtility.systemCopyBuffer = currentRoomCode;
            Debug.Log($"[PAGGER] Room Code {currentRoomCode} copied to clipboard!");
            SoundBGMManager.Instance?.PlayMoneySFX();
        }

        public void OnClickPlayButton()
        {
            if (lobbyPanel != null) lobbyPanel.SetActive(true);
            SoundBGMManager.Instance?.PlayMoneySFX();
        }

        public void OnClickSettingsButton()
        {
            if (settingsPanel != null) settingsPanel.SetActive(true);
        }

        public void OnClickQuitButton()
        {
            Application.Quit();
        }
    }
}
