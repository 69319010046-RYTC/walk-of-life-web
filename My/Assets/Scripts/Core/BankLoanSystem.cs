using UnityEngine;
using WalkOfLife.Character;

namespace WalkOfLife.Core
{
    public class BankLoanSystem : MonoBehaviour
    {
        public static BankLoanSystem Instance { get; private set; }

        public const float loanAmount = 500f;
        public const float loanInterestRate = 0.15f; // 15% interest on debt
        public const float depositInterestRate = 0.10f; // 10% interest on savings

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public bool TakeBankLoan(Character3DController player)
        {
            if (player == null || player.Stats == null) return false;

            player.Stats.ModifyCash(loanAmount);
            player.Stats.bankDebt += loanAmount * (1f + loanInterestRate);

            Debug.Log($"[BANK] {player.Stats.playerName} took a bank loan of ${loanAmount}. Total Debt: ${player.Stats.bankDebt}");
            SoundBGMManager.Instance?.PlayMoneySFX();
            return true;
        }

        public void ApplyRoundInterest(Character3DController player)
        {
            if (player == null || player.Stats == null) return;

            // Savings Interest
            if (player.Stats.bankSavings > 0)
            {
                float interestEarned = player.Stats.bankSavings * depositInterestRate;
                player.Stats.bankSavings += interestEarned;
                player.Stats.ModifyCash(interestEarned);
                Debug.Log($"[BANK] {player.Stats.playerName} earned ${interestEarned} in savings interest.");
            }
        }
    }
}
