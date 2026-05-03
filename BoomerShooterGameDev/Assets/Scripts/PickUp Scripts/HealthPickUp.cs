using UnityEngine;

public class HealthPickUp : PickUpBase
{
    public float healAmount = 25f;

    public override void OnPickUp(Collider player)
    {
        var health = player.GetComponent<Health>();
        if (health != null)
        {
            health.Heal(healAmount);
        }
    }
}