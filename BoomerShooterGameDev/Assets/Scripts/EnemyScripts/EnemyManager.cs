// counting how many enemies are still remaining after enemy dies
using UnityEngine;
public class EnemyManager : MonoBehaviour
{
    public int totalEnemies = 5;

    private void Awake()
    {
        // count how many enemies are in the arena at the start
        totalEnemies = transform.childCount;
    }

    public void HandleEnemyDeath()
    {
        totalEnemies--;

        // if all enemies die, arena cleared 
        if (totalEnemies <= 0)
        {
            ArenaManager.ClearArena();
        }
    }
    
}