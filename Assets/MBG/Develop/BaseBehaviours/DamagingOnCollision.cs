#define WORKAROUND

using UnityEngine;

namespace Assets.MBG.Develop.BaseBehaviours
{
    [RequireComponent(typeof(Collider))]
    public class DamagingOnCollision : MonoBehaviour
    {
        [SerializeField] private int _damage;
#if WORKAROUND
        private bool _hasHitPlayer = false;
#endif
        private void OnCollisionEnter(Collision collision)
        {
            if (_hasHitPlayer)
                return;
            if (collision.gameObject.TryGetComponent(out Damageable damageable) == false)
                return;

            damageable.ApplyDamage(_damage);

            _hasHitPlayer = true;
        }
    }
}
