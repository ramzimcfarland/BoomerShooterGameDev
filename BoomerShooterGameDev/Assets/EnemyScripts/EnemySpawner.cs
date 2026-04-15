// This script was written with the help of Claude AI

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int spawnCount = 3;
    public bool spawnOnStart = false;
    public bool spawnOnTrigger = true; // called externally, e.g. from a trigger volume

    void Start()
    {
        if (spawnOnStart)
            Spawn();
    }

    public void Spawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 randomOffset = new Vector3(
                Random.Range(-3f, 3f),
                0f,
                Random.Range(-3f, 3f)
            );

            GameObject enemy = Instantiate(enemyPrefab, transform.position + randomOffset, transform.rotation);
            EnemyAI ai = enemy.GetComponent<EnemyAI>();
            if (ai != null){
                Debug.Log("activating enemy ai");
                ai.Activate();
            }
        }
    }
}