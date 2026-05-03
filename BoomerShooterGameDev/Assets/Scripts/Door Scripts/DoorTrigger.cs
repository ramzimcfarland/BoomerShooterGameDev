using UnityEngine;
using System;

public class DoorTrigger : MonoBehaviour
{
    public DoorController doorController;
    public static event Action OnPlayerEnter;
    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        // triggered by player 
        if(other.CompareTag("Player") && !hasTriggered)
        {
            //can only trigger once
            hasTriggered = true;

            // close door and invoke player enter event
            if (doorController.isOpen){
                doorController.CloseDoor();
                OnPlayerEnter?.Invoke();
            }
            else
            {
                // for future implementation of opening door
                doorController.OpenDoor();
            }
            
        }
    }

}
