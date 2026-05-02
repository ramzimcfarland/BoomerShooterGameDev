using UnityEngine;
public class EnemyManager : MonoBehaviour
{
    public int totalEnemies = 5;

    private void Awake()
    {
        totalEnemies = transform.childCount;
    }

    public void HandleEnemyDeath()
    {
        totalEnemies--;
        Debug.Log($"Enemy died! Remaining enemies: {totalEnemies}");
        if (totalEnemies <= 0)
        {
            ArenaManager.ClearArena();
        }
    }
    
}