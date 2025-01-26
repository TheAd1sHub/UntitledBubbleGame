using Assets.MBG.Develop.BaseBehaviours;
using Assets.MBG.Develop.Items;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MBG.Develop.MarkerScripts
{
    [RequireComponent(typeof(PlayerMovement),typeof(Damageable))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private List<ItemScriptable> _items = new();

        [field: SerializeField] public int HorizontalSpeed { get; private set; }
        [field: SerializeField] public int VerticalSpeed { get; private set; }

        public int Durability { get; private set; } = 1;
        public int Responsiveness { get; private set; } = 1;
        public PlayerMovement PlayerMovement { get; private set; }

        public Damageable Damageable { get; private set; }

        public List<ItemScriptable> Items => _items;

        private void Awake()
        {
            _items.Clear();
            PlayerMovement = GetComponent<PlayerMovement>();
            Damageable = GetComponent<Damageable>();

            AssignStats();
        }
        private void AssignStats()
        {
            foreach (var item in Items)
            {
                Durability += item.Durability;
                Responsiveness += item.Responsiveness;
            }
        }
    }

}
