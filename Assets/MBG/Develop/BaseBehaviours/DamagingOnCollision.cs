using UnityEngine;

namespace Assets.MBG.Develop
{
    [RequireComponent(typeof(Collider))]
    public class DamagingOnCollision : MonoBehaviour
    {
        [SerializeField] private int _damage;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Damageable>(out Damageable damageable) == false)
                return;
            damageable.ApplyDamage(_damage);
        }
    }
}
