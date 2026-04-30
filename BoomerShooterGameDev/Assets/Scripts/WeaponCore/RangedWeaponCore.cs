//AI
using UnityEngine;
using System;
using System.Collections;
using Unity.VisualScripting;

public abstract class RangedWeaponCore : WeaponCore
{
    [SerializeField] private int _magazineSize = 30;
    [SerializeField] private float _reloadTime = 2f;

    public int  AmmoInMagazine { get; private set; }
    public bool IsReloading { get; private set; }


    public event Action OnAmmoChanged;
    public event Action OnReloadStart;
    public event Action OnReloadComplete;

    protected void Awake() => AmmoInMagazine = _magazineSize;

private bool IsPlayerWeapon => GetComponentInParent<PlayerMovement>() != null;

    public override void TryFire()
    {
        if (IsReloading || AmmoInMagazine <= 0) return;
        base.TryFire();
        AmmoInMagazine--;
        OnAmmoChanged?.Invoke();
        
        // update the ui for player's ammo only
        if (IsPlayerWeapon)
            HUDManager.Instance?.UpdateAmmo(AmmoInMagazine, _magazineSize);

        if (AmmoInMagazine == 0)
            StartCoroutine(ReloadRoutine());
    }

    public void TryReload()
    {
        if (!IsReloading && AmmoInMagazine < _magazineSize)
            StartCoroutine(ReloadRoutine());
    }

    private IEnumerator ReloadRoutine()
    {
        Debug.Log("Is Reloading");
        IsReloading = true;
        OnReloadStart?.Invoke();

        yield return new WaitForSeconds(_reloadTime);

        AmmoInMagazine = _magazineSize;
        IsReloading    = false;
        OnAmmoChanged?.Invoke();
        OnReloadComplete?.Invoke();

        // update the ui for player's ammo only
        if (IsPlayerWeapon)
            HUDManager.Instance?.UpdateAmmo(AmmoInMagazine, _magazineSize);
    }
}