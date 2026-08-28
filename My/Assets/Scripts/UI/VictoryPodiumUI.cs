using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WalkOfLife.Character;
using WalkOfLife.Core;

namespace WalkOfLife.UI
{
    public class VictoryPodiumUI : MonoBehaviour
    {
        public GameObject victoryPanel;
        public Transform podiumContainer;
        public GameObject playerPodiumCardPrefab;

        public void DisplayVictoryScreen(List<Character3DMovement> players)
        {
            if (victoryPanel != null) victoryPanel.SetActive(true);
            SoundBGMManager.Instance?.PlayFanfareSFX();

            // Sort players by Victory Points descending
            players.Sort((a, b) => b.Stats.CalculateVictoryPoints().CompareTo(a.Stats.CalculateVictoryPoints()));

            for (int i = 0; i < players.Count; i++)
            {
                Character3DMovement p = players[i];
                int vp = p.Stats.CalculateVictoryPoints();
                Debug.Log($"[PODIUM] #{i+1} Place: {p.Stats.playerName} with {vp} Victory Points!");
            }
        }
    }
}
