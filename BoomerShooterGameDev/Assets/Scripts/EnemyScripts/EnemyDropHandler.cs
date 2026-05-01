using UnityEngine;

public class DropHandler : MonoBehaviour
{
   [SerializeField] private EnemyDropInventory dropInventory;
   [SerializeField] private float dropRadius = 1f;

    private void Awake()
    {
        GetComponent<Health>().OnDeath += HandleDeath;
    }
   public void HandleDeath()
    {
        foreach (var entry in dropInventory.entries)
        {
            if (Random.value <= entry.chance)
            {
                Vector3 randomOffset = new Vector3(Random.Range(-dropRadius, dropRadius), 0f, Random.Range(-dropRadius, dropRadius));

                Instantiate(entry.itemPrefab, transform.position + randomOffset, Quaternion.identity);
            }
        }
    }
}