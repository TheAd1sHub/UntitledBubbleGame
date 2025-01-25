using Assets.MBG.Develop.CommonServices.SaveHandling;
using UnityEngine;

public class ConfigTest : MonoBehaviour
{
    [SerializeField] private PlayerConfig _config;

    private void Awake()
    {
        _config = SavesHandler.Instance.Load();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            print("Saving...");
            SavesHandler.Instance.Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            print("Loading...");
            _config = SavesHandler.Instance.Load();
        }
    }
}
