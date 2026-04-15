// This script was written with the help of Claude AI
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public EnemySpawner[] spawners; // hook up in inspector

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log("spawn triggered!");
        foreach (var spawner in spawners)
            spawner.Spawn();

        Destroy(gameObject); // one shot trigger
    }
}