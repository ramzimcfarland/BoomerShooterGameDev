//AI
using UnityEngine;
using System;

public abstract class RangedWeaponCore : WeaponCore
{
    [SerializeField] private int _magazineSize = 30;
    [SerializeField] private float _reloadTime = 2f;

    public int  AmmoInMagazine { get; private set; }
    public bool IsReloading { get; private set; }

    public event Action OnAmmoChanged;
    public event Action OnReloadStart;
    public event Action OnReloadComplete;

    private void Awake() => AmmoInMagazine = _magazineSize;

    public new void TryFire()
    {
        //if (IsReloading || AmmoInMagazine <= 0) return;
        base.TryFire();
        //AmmoInMagazine--;
       // OnAmmoChanged?.Invoke();

        // if (AmmoInMagazine == 0)
            // StartCoroutine(ReloadRoutine());
    }

    public void TryReload()
    {
        if (!IsReloading && AmmoInMagazine < _magazineSize)
            StartCoroutine(ReloadRoutine());
    }

    private System.Collections.IEnumerator ReloadRoutine()
    {
        IsReloading = true;
        OnReloadStart?.Invoke();

        yield return new WaitForSeconds(_reloadTime);

        AmmoInMagazine = _magazineSize;
        IsReloading    = false;
        OnAmmoChanged?.Invoke();
        OnReloadComplete?.Invoke();
    }
}