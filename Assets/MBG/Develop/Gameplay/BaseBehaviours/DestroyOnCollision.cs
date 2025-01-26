#define WORKAROUND

using Assets.MBG.Develop.MarkerScripts;
using UnityEngine;

namespace Assets.MBG.Develop.BaseBehaviours
{
    [RequireComponent(typeof(Collider))]
    public class DestroyOnCollision : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out _) == false)
                return;

            Destroy(gameObject);
        }
    }
}
