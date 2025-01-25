using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Assets.MBG.Develop
{
    [RequireComponent(typeof(PlayerMovement))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private List<ItemScriptable> _items = new();

        [field: SerializeField] public int Speed { get; private set; }

        public int Durability { get; private set; } = 1;
        public int Responsiveness { get; private set; } = 1;
        public PlayerMovement PlayerMovement { get; private set; }

        public List<ItemScriptable> Items => _items;

        private void Awake()
        {
            PlayerMovement = GetComponent<PlayerMovement>();
            
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
