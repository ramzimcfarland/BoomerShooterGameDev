using UnityEngine;
using System;

public abstract class EnemyRangedCore : WeaponCore
{
    [SerializeField] private float _reloadTime = 2f;

    [SerializeField] private int _magazineSize = 5;

    public int  AmmoInMagazine { get; private set; }
    public bool IsReloading { get; private set; }

    // public event Action OnAmmoChanged;
    // public event Action OnReloadStart;
    // public event Action OnReloadComplete;

    void Awake()
    {
        _fireRate = 5;
        AmmoInMagazine = _magazineSize;
    }


    public new void TryFire()
    {
        if (IsReloading || AmmoInMagazine <= 0) return;
        base.TryFire();
        AmmoInMagazine--;
        // OnAmmoChanged?.Invoke();

        if (AmmoInMagazine == 0)
            StartCoroutine(ReloadRoutine());
    }
    private System.Collections.IEnumerator ReloadRoutine()
    {
        IsReloading = true;
        // OnReloadStart?.Invoke();

        yield return new WaitForSeconds(_reloadTime);

        AmmoInMagazine = _magazineSize;
        IsReloading    = false;
        // OnAmmoChanged?.Invoke();
        // OnReloadComplete?.Invoke();
    }
}