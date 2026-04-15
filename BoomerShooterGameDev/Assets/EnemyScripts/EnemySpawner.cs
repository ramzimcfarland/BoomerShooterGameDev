// This script was written with the help of Claude AI

using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
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
            NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
            agent.avoidancePriority = Random.Range(1, 99); // randomize priority to prevent clumping
            
            if (ai != null){
                Debug.Log("activating enemy ai");
                ai.player = player;
                ai.Activate();
            }
        }
    }
}