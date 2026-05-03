using UnityEngine;
using System;

public class DoorTrigger : MonoBehaviour
{
    public DoorController doorController;
    public static event Action OnPlayerEnter;
    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;

            if (doorController.isOpen){
                doorController.CloseDoor();
                OnPlayerEnter?.Invoke();
            }
            else
            {
                doorController.OpenDoor();
            }
            
        }
    }

}
