using Assets.MBG.Develop.CommonServices.SceneManagement;
using System.Collections;
using UnityEngine;

namespace Assets.MBG.Develop.VictoryScreen
{
    public class VictoryScreenSwitch : MonoBehaviour
    {
        [SerializeField] private float _displayDurationSeconds = 5f;
        [SerializeField] private string _mainMenuSceneName = "MainMenu";

        private void Start() => StartCoroutine(ReturnToMenuOnTimeout());

        private IEnumerator ReturnToMenuOnTimeout()
        {
            yield return new WaitForSecondsRealtime(_displayDurationSeconds);
            StartCoroutine(SceneChanger.LoadSceneAsync(_mainMenuSceneName));
        }
    }
}
