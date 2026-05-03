// base class for pickupable objects
using UnityEngine;

[RequireComponent(typeof(Collider))] // makes sure there is a collider
public abstract class PickUpBase : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        OnPickUp(other);
        Destroy(gameObject);
    }

    public abstract void OnPickUp(Collider player);
}