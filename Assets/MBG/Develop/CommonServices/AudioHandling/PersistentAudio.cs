using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentAudio : MonoBehaviour
{
    private static PersistentAudio instance; // Singleton instance

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object when loading new scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }
}
