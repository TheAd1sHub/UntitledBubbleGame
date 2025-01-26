using Assets.MBG.Develop.CommonServices.SceneManagement;
using Assets.MBG.Develop.MarkerScripts;
using System;
using UnityEngine;

namespace Assets.MBG.Develop.BaseBehaviours
{
    public class Damageable : MonoBehaviour
    {
        public event Action Damaged;
        public event Action Killed;
        
        public int Health { get; private set; }

        public void ApplyDamage(int damage)
        {
            if (Health <= 0)
                return;

            Health -= damage;
            Damaged?.Invoke();

            if (Health <= 0)
                StartCoroutine(SceneChanger.LoadSceneAsync(SceneID.CustomizationMenu.ToString()));
        }

        private void OnDamaged() { print("got dmgd"); }

        private void OnKilled() { StartCoroutine(SceneChanger.LoadSceneAsync(SceneID.CustomizationMenu)); }

        private void Start()
        {
            Damaged += OnDamaged;
            Killed += OnKilled;

            if (TryGetComponent(out Player player) == false)
                return;

            Health = player.Durability;
        }

    }
}
