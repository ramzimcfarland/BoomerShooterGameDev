// items for enemies to drop upon death
using UnityEngine;
using System;

public class EnemyDropInventory : MonoBehaviour
{
    [SerializeField] public DropEntry[] entries;

    [Serializable]
    public class DropEntry
    {
        public GameObject itemPrefab;
        [Range(0f, 1f)] public float chance; // chance of the item dropping
    }

}