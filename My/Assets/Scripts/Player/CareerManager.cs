using System.Collections.Generic;
using UnityEngine;

namespace WalkOfLife.Player
{
    [System.Serializable]
    public class JobDefinition
    {
        public string title;
        public int requiredEducation; // 0: None, 1: Bachelor, 2: Master, 3: Doctorate
        public float payPerShift;
        public float energyCost;
        public float stressCost;       // Happiness penalty per shift

        public JobDefinition(string title, int reqEdu, float pay, float energy, float stress)
        {
            this.title = title;
            this.requiredEducation = reqEdu;
            this.payPerShift = pay;
            this.energyCost = energy;
            this.stressCost = stress;
        }
    }

    public class CareerManager : MonoBehaviour
    {
        public static CareerManager Instance { get; private set; }

        public List<JobDefinition> availableJobs = new List<JobDefinition>();

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);

            InitializeJobs();
        }

        private void InitializeJobs()
        {
            availableJobs.Add(new JobDefinition("Part-time Staff", 0, 90f, 20f, 5f));
            availableJobs.Add(new JobDefinition("Office Associate", 1, 220f, 25f, 10f));
            availableJobs.Add(new JobDefinition("Senior Manager", 2, 480f, 30f, 15f));
            availableJobs.Add(new JobDefinition("Chief Executive Officer (CEO)", 3, 1050f, 35f, 20f));
        }

        public bool PromoteJob(PlayerStats player)
        {
            int nextJobIndex = player.educationLevel;
            if (nextJobIndex < availableJobs.Count)
            {
                JobDefinition newJob = availableJobs[nextJobIndex];
                player.currentJobTitle = newJob.title;
                player.jobSalary = newJob.payPerShift;
                Debug.Log($"{player.playerName} promoted to {newJob.title}!");
                return true;
            }
            return false;
        }

        public JobDefinition GetJobForPlayer(PlayerStats player)
        {
            int idx = Mathf.Clamp(player.educationLevel, 0, availableJobs.Count - 1);
            return availableJobs[idx];
        }
    }
}
