using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    // trigger when walk into the light at last level
    public static bool isTriggered = false;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        if (other.CompareTag("Player"))
        {
            Debug.Log("light triggered!");
            isTriggered = true;
            ArenaManager.ClearArena(); 
        }
    }   
}