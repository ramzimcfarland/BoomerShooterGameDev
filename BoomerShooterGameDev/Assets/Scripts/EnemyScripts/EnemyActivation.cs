// assisted by Claude AI
// used to activate enemies after player has left the waiting room
using System.Collections;
using UnityEngine;

public class EnemyActivation : MonoBehaviour
{
    // all enemies that should be activated at the start of level
    public EnemyAI[] enemies;        
    public float activationDelay = 3f;

     void Start()
    {
        enemies = FindObjectsByType<EnemyAI>(FindObjectsSortMode.None);
    }

    void OnEnable()
    {
        DoorTrigger.OnPlayerEnter += StartLevel;
    }

    void OnDisable()
    {
        DoorTrigger.OnPlayerEnter -= StartLevel;
    }

    void StartLevel()
    {
        StartCoroutine(ActivateAfterDelay());
    }

    IEnumerator ActivateAfterDelay()
    {
        // a few seconds buffer for door to close / to allow player to adjust
        yield return new WaitForSeconds(activationDelay);

        //activate enemies
        foreach (var enemy in enemies)
        {
            enemy.Activate();
        }
    }
}