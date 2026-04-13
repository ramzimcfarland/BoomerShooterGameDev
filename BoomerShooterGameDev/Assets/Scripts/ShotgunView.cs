using UnityEngine;

public class ShotgunView : MonoBehaviour
{
    [SerializeField] private Shotgun _shotgun;

    private void Awake()
    {
        // _shotgun.OnHit    += HandleHit;
        _shotgun.OnFire   += HandleFire;
        // _shotgun.OnEquip  += HandleEquip;
        // _shotgun.OnUnequip += HandleUnequip;
    }

    private void OnDestroy()
    {
        // _shotgun.OnHit     -= HandleHit;
        _shotgun.OnFire    -= HandleFire;
        // _shotgun.OnEquip   -= HandleEquip;
        // _shotgun.OnUnequip -= HandleUnequip;
    }

    // private void HandleHit(Vector3 point, Vector3 normal) { /* VFX, sound */ }
     private void HandleFire()                             { /* muzzle flash */ }
    // private void HandleEquip()                            { /* draw animation */ }
    // private void HandleUnequip() 
}