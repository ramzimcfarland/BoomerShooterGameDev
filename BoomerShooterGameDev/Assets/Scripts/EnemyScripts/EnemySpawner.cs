// This script was written with the help of Claude AI

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI[] enemies; // drag in pre-placed enemies in inspector
    public Transform player;

    // set deactivated enemies to be active when triggered by the spawn trigger
    public void Spawn()
    {
        foreach (EnemyAI ai in enemies)
        {
            ai.gameObject.SetActive(true);
            ai.player = player;
            ai.Activate();
        }
    }
}


