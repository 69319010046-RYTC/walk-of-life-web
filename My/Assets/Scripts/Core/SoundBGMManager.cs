using UnityEngine;

namespace WalkOfLife.Core
{
    public class SoundBGMManager : MonoBehaviour
    {
        public static SoundBGMManager Instance { get; private set; }

        [Header("Audio Sources")]
        public AudioSource bgmSource;
        public AudioSource sfxSource;

        [Header("Audio Clips")]
        public AudioClip boardMapBGM;
        public AudioClip interiorBGM;
        public AudioClip victoryBGM;
        public AudioClip stepSFX;
        public AudioClip moneySFX;
        public AudioClip fanfareSFX;
        public AudioClip hospitalAmbulanceSFX;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        public void PlayBGM(AudioClip clip)
        {
            if (bgmSource != null && clip != null)
            {
                bgmSource.clip = clip;
                bgmSource.loop = true;
                bgmSource.Play();
            }
        }

        public void PlaySFX(AudioClip clip)
        {
            if (sfxSource != null && clip != null)
            {
                sfxSource.PlayOneShot(clip);
            }
        }

        public void PlayMoneySFX() => PlaySFX(moneySFX);
        public void PlayStepSFX() => PlaySFX(stepSFX);
        public void PlayFanfareSFX() => PlaySFX(fanfareSFX);
        public void PlayHospitalAmbulanceSFX() => PlaySFX(hospitalAmbulanceSFX);
    }
}
