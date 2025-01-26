using Assets.MBG.Develop.CommonServices.AudioHandling;
using Assets.MBG.Develop.CommonServices.CoroutinesHandling;
using Assets.MBG.Develop.CommonServices.SaveHandling;
using Assets.MBG.Develop.CommonServices.SceneManagement;
using Assets.MBG.Develop.ScenePersistence;
using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace Assets.MBG.Develop.Bootstrap
{
    public sealed class Bootstrap : MonoBehaviour
    {
        private static bool _wasInitialized = false;

        [SerializeField] private string _firstScene = SceneID.MainMenu.ToString();

        public void Initialize()
        {
            if (_wasInitialized)
                throw new InvalidOperationException("Bootstrap was already initialized during this session");

            // Loading player's saves
            SavesHandler savesHandler = SavesHandler.Instance;
            savesHandler.Load();

            // Initializing general services
            ICoroutinesHandler coroutinesHandler = CoroutinesHandler.Instance;

            // Initializing data transfer services
            PlayerDataTransferer dataTransferer = PlayerDataTransferer.Instance;

            // Initializing sound
            ChannelsVolumeHandler volumeHandler = ChannelsVolumeHandler.Instance;

            _wasInitialized = true;
        }

        private void Awake()
        {
            Initialize();
            CoroutinesHandler.Instance.StartRoutine(SceneChanger.LoadSceneAsync(_firstScene));
        }
    }
}
