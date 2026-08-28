using System.Collections;
using UnityEngine;
using WalkOfLife.Player;
using WalkOfLife.Core;

namespace WalkOfLife.AI
{
    public class AIBotController : MonoBehaviour
    {
        private PlayerController botController;

        public void TakeTurn(PlayerController controller, int currentRound, int maxRounds, System.Action onTurnComplete)
        {
            botController = controller;
            StartCoroutine(AITurnRoutine(currentRound, maxRounds, onTurnComplete));
        }

        private IEnumerator AITurnRoutine(int currentRound, int maxRounds, System.Action onTurnComplete)
        {
            PlayerStats stats = botController.Stats;
            int actionsTaken = 0;

            while (stats.energy >= 15f && actionsTaken < 5)
            {
                yield return new WaitForSeconds(0.4f);

                // Priority 1: Survival & Health
                if (stats.hunger >= 60f && stats.cash >= 30f)
                {
                    botController.EatMeal();
                }
                else if (stats.health <= 40f)
                {
                    botController.Rest();
                }
                // Priority 2: Late game victory points push (Furniture Decor)
                else if (currentRound >= maxRounds - 8 && stats.cash >= 400f)
                {
                    botController.BuyFurniture("Luxury Gaming Chair", 350f, 250f);
                }
                // Priority 3: Education & Promotion
                else if (stats.cash >= 300f && stats.educationLevel < 3 && stats.energy >= 35f)
                {
                    botController.Study();
                }
                // Priority 4: Work to earn money
                else if (stats.energy >= 20f)
                {
                    botController.Work();
                }
                else
                {
                    botController.Rest();
                    break;
                }

                actionsTaken++;
            }

            yield return new WaitForSeconds(0.2f);
            onTurnComplete?.Invoke();
        }
    }
}
