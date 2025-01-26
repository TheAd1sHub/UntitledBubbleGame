using UnityEngine;

namespace Assets.MBG.Develop.CommonServices.SceneManagement
{
    public sealed class SceneChangerWrapper : MonoBehaviour
    {
        public void LoadSceneAsync(SceneID scene) => StartCoroutine(SceneChanger.LoadSceneAsync(scene));
        public void LoadSceneAsync(string sceneName) => StartCoroutine(SceneChanger.LoadSceneAsync(sceneName));
        public void doExitGame() { Application.Quit(); Debug.Log("Game is exiting"); }
    }
}
