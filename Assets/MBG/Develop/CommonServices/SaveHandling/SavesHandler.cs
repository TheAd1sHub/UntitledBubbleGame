using System.IO;
using UnityEngine;

namespace Assets.MBG.Develop.CommonServices.SaveHandling
{
    public sealed class SavesHandler : MonoBehaviour
    {
        #region Singleton implementation
        private static SavesHandler _instance;
        private static readonly object _instanceLock = new();

        public static SavesHandler Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceLock)
                    {
                        if (_instance == null)
                        {
                            GameObject instanceObject = new GameObject("[SAVES HANDLER]");
                            _instance = instanceObject.AddComponent<SavesHandler>();

                            DontDestroyOnLoad(instanceObject);
                        }
                    }
                }

                return _instance;
            }
        }
        #endregion

        public PlayerConfig LastSaveData { get; private set; }
        public PlayerConfig DefaultConfig { get; set; } = new PlayerConfig()
        {
            LastChosenMaterialId = 1,
            LastChosenLiquidId = 1,
        };

        public static string SavePath => Path.Combine(Application.persistentDataPath, "save.json");
        
        public PlayerConfig Load()
        { 
            LastSaveData = File.Exists(SavePath)
                ? JSONSerializer.Deserialize<PlayerConfig>(File.ReadAllText(SavePath))
                : DefaultConfig;

            return LastSaveData;
        }

        public void Save()
        {
            string configJson = JSONSerializer.Serialize(LastSaveData);

            if (File.Exists(SavePath) == false)
                File.Create(SavePath).Close();

            File.WriteAllText(SavePath, configJson);
        }
    }
}
