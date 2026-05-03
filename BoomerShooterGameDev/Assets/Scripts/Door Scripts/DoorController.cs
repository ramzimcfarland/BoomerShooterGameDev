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
        isOpen = openAtStart;

        closedPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - closedYOffset, transform.localPosition.z);
        openPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + openYOffset, transform.localPosition.z);

        transform.localPosition = openAtStart ? openPosition : closedPosition;
    }

    public void CloseDoor()
    {
        if (!isAnimating)
            StartCoroutine(AnimateDoor(closedPosition));
            SoundManager.PlaySound(SoundType.DOORBOOM);
        isOpen = false;
    }

    public void OpenDoor()
    {
        if (!isAnimating)
            StartCoroutine(AnimateDoor(openPosition));
        isOpen = true;
    }

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
