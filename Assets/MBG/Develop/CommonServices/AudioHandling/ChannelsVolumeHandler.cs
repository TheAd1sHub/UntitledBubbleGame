using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.MBG.Develop.CommonServices.AudioHandling
{
    public sealed class ChannelsVolumeHandler : MonoBehaviour
    {
        private const string MasterVolumeName = "masterVolume";
        private const string MusicVolumeName = "musicVolume";
        private const string SoundFXVolumeName = "soundsVolume";

        [SerializeField, Range(-80, 0)] private float _masterVolume;
        [SerializeField, Range(-80, 0)] private float _musicVolume;
        [SerializeField, Range(-80, 0)] private float _soundVolume;

        [SerializeField] private AudioMixer _audioMixer;

        public static ChannelsVolumeHandler Instance { get; private set; }

        public void SetMasterVolume(float value)
            => SetChannelVolume(MasterVolumeName, value);

        public void SetSoundFXVolume(float value)
            => SetChannelVolume(SoundFXVolumeName, value);

        public void SetMusicVolume(float value)
            => SetChannelVolume(MusicVolumeName, value);

        public void SetChannelVolume(string channelName, float value)
        {
            Debug.Assert(-80 <= value && value <= 0);
            _audioMixer.SetFloat(channelName, value);
        }

        private void OnValidate()
        {
            SetMasterVolume(_masterVolume);
            SetSoundFXVolume(_soundVolume);
            SetMusicVolume(_musicVolume);
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError($"Cannot create {name}; Another instance of {nameof(ChannelsVolumeHandler)} exists on {Instance.name}");
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
