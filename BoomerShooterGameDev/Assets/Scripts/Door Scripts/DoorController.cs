//Claude AI helped write this script
using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    [Header("Door Settings")]
    public float openYOffset = 0f;
    public float closedYOffset = 5f;
    public float movementSpeed = 2f;
    public bool openAtStart = true;

    private Vector3 openPosition;
    private Vector3 closedPosition;

    private bool isAnimating = false;
    public bool isOpen;

    void Start()
    {
        SoundManager.PlayMusic(MusicType.WAITINGROOM);
        isOpen = openAtStart;

        //set closed and open positions
        closedPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - closedYOffset, transform.localPosition.z);
        openPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + openYOffset, transform.localPosition.z);

        // set door to correct position
        transform.localPosition = openAtStart ? openPosition : closedPosition;
    }

    public void CloseDoor()
    {
        //start door closing animation then start sfx and music
        if (!isAnimating)
            StartCoroutine(AnimateDoor(closedPosition));
            SoundManager.PlaySound(SoundType.DOORBOOM);
            SoundManager.StopMusic();
            SoundManager.PlayMusic(MusicType.GAMEPLAY);
        isOpen = false;
    }

    //for future implementation of opening doors
    public void OpenDoor()
    {
        if (!isAnimating)
            StartCoroutine(AnimateDoor(openPosition));
        isOpen = true;
    }

    // coroutine to animate door
    private IEnumerator AnimateDoor(Vector3 targetPosition)
    {
        isAnimating = true;
        SoundManager.PlaySound(SoundType.DOORCLOSING);
        while (Vector3.Distance(transform.localPosition, targetPosition) > 0.01f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, movementSpeed * Time.deltaTime);
            yield return null;
        }
        transform.localPosition = targetPosition;
        isAnimating = false;
    }

}
