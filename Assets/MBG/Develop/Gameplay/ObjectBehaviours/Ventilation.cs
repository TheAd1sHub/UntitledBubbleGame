using UnityEngine;

namespace Assets.MBG.Develop.ObjectBehaviours
{
    [RequireComponent(typeof(Collider))]
    public class Ventilation : MonoBehaviour
    {
        [SerializeField] private float forceMultiplier = 0.004f;  // Strength of the ventilation
        [SerializeField] private float maxForce = 0.004f;  // Limit max force to avoid extreme speeds

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out PlayerJoystickMovement playerMovement))
            {
                Vector3 direction = (playerMovement.transform.position - transform.position).normalized;
                float distance = Vector3.Distance(playerMovement.transform.position, transform.position);

                if (distance > 0.1f)
                {
                    float force = Mathf.Clamp(forceMultiplier / distance, 0, maxForce);
                    playerMovement.ApplyForce(direction * force);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerJoystickMovement playerMovement))
            {
                playerMovement.ClearExternalForce();
            }
        }
    }
}
