using System;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        private static bool _initialized;

        [SerializeField] private AudioMixerGroup audioMixerGroup;
        
        [Header("Music")]
        [SerializeField] private AudioSource musicSource;
        
        [Header("FX")]
        [SerializeField] private AudioSource fxSource;
        [SerializeField] private float minPitch = .8f;
        [SerializeField] private float maxPitch = 1.2f;

        public bool fxMuted;
        public bool musicMuted; 
        
        void Awake()
        {
            if (_initialized)
            {
                Destroy(gameObject);
                return;
            }
            _initialized = true;
            Instance = this;
            DontDestroyOnLoad(gameObject);
            CheckForMute();
        }

        public void CheckForMute()
        {
            var musicVolume = PlayerPrefs.GetFloat("music", 0f);
            var fxVolume = PlayerPrefs.GetFloat("fx", 0f);

            fxMuted = musicVolume < 0f;
            musicMuted = musicVolume < 0f;

            audioMixerGroup.audioMixer.SetFloat("musicVolume",musicVolume);
            audioMixerGroup.audioMixer.SetFloat("fxVolume",fxVolume);
        }

        public void PlayAudioFX(AudioClip audioClip)
        {
            fxSource.pitch = Random.Range(minPitch, maxPitch);
            fxSource.clip = audioClip;
            fxSource.Play();
        }

        public void PlayMusic() => musicSource.Play();

        public void StopMusic() => musicSource.Stop();

        public void ToggleFx(bool isOn)
        {
            PlayerPrefs.SetFloat("fx", isOn ? 0f : -80f);
            CheckForMute();
        }

        public void ToggleMusic(bool  isOn)
        {
            PlayerPrefs.SetFloat("music", isOn ? 0f : -80f);
            CheckForMute();
        }
    }
}
