using UnityEngine;

namespace Assets.MBG.Develop.ObjectBehaviours
{
    [RequireComponent(typeof(Collider))]
    public class Ventilation : MonoBehaviour
    {
        [SerializeField] private float forceMultiplier;

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out PlayerMovement playerMovement) == false)
                return;

            Vector3 direction = (playerMovement.gameObject.transform.position - transform.position).normalized;

            float distance = Vector3.Distance(playerMovement.gameObject.transform.position, transform.position);

            if (distance != 0f)
            {
                float force = forceMultiplier / distance;
                playerMovement.ApplyForce(direction * force);
            }
        }
    }
}
