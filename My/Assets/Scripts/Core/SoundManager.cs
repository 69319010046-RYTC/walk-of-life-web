using UnityEngine;

namespace WalkOfLife.Core
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }

        [Header("Audio Sources")]
        public AudioSource sfxSource;
        public AudioSource bgmSource;

        [Header("Audio Clips")]
        public AudioClip stepClip;
        public AudioClip moneyClip;
        public AudioClip victoryClip;
        public AudioClip clickClip;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void PlaySFX(AudioClip clip)
        {
            if (sfxSource != null && clip != null)
            {
                sfxSource.PlayOneShot(clip);
            }
        }

        public void PlayMoneySound() => PlaySFX(moneyClip);
        public void PlayStepSound() => PlaySFX(stepClip);
        public void PlayVictorySound() => PlaySFX(victoryClip);
        public void PlayClickSound() => PlaySFX(clickClip);
    }
}
