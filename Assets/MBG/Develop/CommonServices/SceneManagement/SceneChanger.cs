using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.MBG.Develop.CommonServices.SceneManagement
{
    public static class SceneChanger
    {
        public static IEnumerator LoadSceneAsync(SceneID scene, LoadSceneMode mode = LoadSceneMode.Single)
            => LoadSceneAsync(scene, mode);

        public static IEnumerator LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
        {
            AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(sceneName, mode);

            while (sceneLoading.isDone == false)
                yield return null;
        }
    }
}
