using UnityEngine;
using System;

public class EnemyDropInventory : MonoBehaviour
{
    [SerializeField] public DropEntry[] entries;

    [Serializable]
    public class DropEntry
    {
        public GameObject itemPrefab;
        [Range(0f, 1f)] public float chance;
    }

}