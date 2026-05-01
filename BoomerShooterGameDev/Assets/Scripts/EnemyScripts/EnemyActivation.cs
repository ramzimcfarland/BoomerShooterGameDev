// assisted by Claude AI
using System.Collections;
using UnityEngine;

public class EnemyActivation : MonoBehaviour
{
    public EnemyAI[] enemies;        // drag your scene enemies in here
    public float activationDelay = 3f;

     void Start()
    {
        enemies = FindObjectsByType<EnemyAI>(FindObjectsSortMode.None);
        Debug.Log("Found " + enemies.Length + " enemies");
    }

    void OnEnable()
    {
        DoorTrigger.OnPlayerEnter += StartLevel;
        Debug.Log("EnemyActivation subscribed on: " + gameObject.name + " with " + enemies.Length + " enemies");
    }

    void OnDisable()
    {
        DoorTrigger.OnPlayerEnter -= StartLevel;
    }

    void StartLevel()
    {
        Debug.Log("StartLevel called");
        StartCoroutine(ActivateAfterDelay());
    }

    IEnumerator ActivateAfterDelay()
    {
        Debug.Log("Waiting " + activationDelay + " seconds");
        yield return new WaitForSeconds(activationDelay);
        Debug.Log("Activating " + enemies.Length + " enemies");


        foreach (var enemy in enemies)
        {
            Debug.Log("Activating: " + enemy.name);
            enemy.Activate();
        }
    }
}