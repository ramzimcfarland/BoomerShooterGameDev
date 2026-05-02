using UnityEngine;

public class HealthPickUp : PickUpBase
{
    public float healAmount = 25f;
    //public AudioClip pickupSound;

    public override void OnPickUp(Collider player)
    {
        var health = player.GetComponent<Health>();
        if (health != null)
        {
            health.Heal(healAmount);
            //AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            Debug.Log("picked up health");
        }
    }
}