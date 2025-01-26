using Assets.MBG.Develop.CommonServices.SceneManagement;
using Assets.MBG.Develop.MarkerScripts;
using UnityEngine;

namespace Assets.MBG.Develop.VictoryScreen
{
    [RequireComponent(typeof(Collider))]
    public sealed class VictoryCollider : MonoBehaviour
    {
        [SerializeField] private string _victoryScreenSceneName = "VictoryScreen";

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out _) == false)
                return;

            StartCoroutine(SceneChanger.LoadSceneAsync(_victoryScreenSceneName));
        }
    }
}
