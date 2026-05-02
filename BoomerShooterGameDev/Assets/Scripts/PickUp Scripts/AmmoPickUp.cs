using Unity.VisualScripting;
using UnityEngine;

public class AmmoPickUp : PickUpBase
{
    public int ammoAmount = 15;

    public override void OnPickUp(Collider player)
    {
        RangedWeaponCore weapon = player.GetComponentInChildren<RangedWeaponCore>();
        if (weapon == null) return;
        
        weapon.AddAmmoToInventory(ammoAmount);
        Debug.Log("picked up ammo");
    }
}