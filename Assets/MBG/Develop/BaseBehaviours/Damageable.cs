using System;
using UnityEngine;

namespace Assets.MBG.Develop
{
    public class Damageable : MonoBehaviour
    {
        public event Action Damaged;
        public event Action Killed;

        private Player _player;

        public int Health;

        public void ApplyDamage(int damage)
        {
            Health -= damage;
            Damaged?.Invoke();

            if(Health <= 0 ) 
                Killed?.Invoke();
        }

        private void OnDamaged()
        {

        }

        private void OnKilled()
        {
            Debug.Log("u ded");
        }

        private void Start()
        {
            Damaged += OnDamaged;
            Killed += OnKilled;

            if (TryGetComponent<Player>(out Player player) == false)
                return;

           _player = player;
            Health = player.Durability;
        }

    }
}
