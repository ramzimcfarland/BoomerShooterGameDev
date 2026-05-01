//AI
using UnityEngine;
using System;
using System.Collections;
using Unity.VisualScripting;

public abstract class RangedWeaponCore : WeaponCore
{
    [SerializeField] private int _magazineSize = 30;
    [SerializeField] private float _reloadTime = 2f;
    [SerializeField] private int _maxInventoryAmmo = 90; // New field for maximum reserve ammo

    public int  AmmoInMagazine { get; private set; }
    public bool IsReloading { get; private set; }
    public int AmmoInventory { get; private set; }  


    public event Action OnAmmoChanged;
    public event Action OnReloadStart;
    public event Action OnReloadComplete;

    protected virtual void Awake()
    {
        AmmoInMagazine = _magazineSize;
        AmmoInventory = _maxInventoryAmmo/2;
    }

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
        if (!IsReloading && AmmoInMagazine < _magazineSize && AmmoInventory > 0)
            StartCoroutine(ReloadRoutine());
    }

    private IEnumerator ReloadRoutine()
    {
        Debug.Log("Is Reloading");
        IsReloading = true;
        OnReloadStart?.Invoke();

        yield return new WaitForSeconds(_reloadTime);

        // AmmoInMagazine = _magazineSize; // infinite ammo

        AmmoInMagazine = ReloadAmmo();

        IsReloading    = false;
        OnAmmoChanged?.Invoke();
        OnReloadComplete?.Invoke();

        // update the ui for player's ammo only
        if (IsPlayerWeapon)
        {
            Debug.Log("updating hud for ammo");
            HUDManager.Instance?.UpdateAmmo(AmmoInMagazine, _magazineSize);
        }
    }

    private int ReloadAmmo()
    {
        int freeSpace = _magazineSize - AmmoInMagazine;
        int ammoToReload = Mathf.Min(freeSpace, AmmoInventory);
        AmmoInventory -= ammoToReload;

        Debug.Log($"Reloaded {ammoToReload} ammo. Ammo in magazine: {AmmoInMagazine}, Ammo in inventory: {AmmoInventory}");

        return AmmoInMagazine + ammoToReload;
    }

    public void AddAmmoToInventory(int amount)
    {
        Debug.Log($"Adding {amount} ammo to inventory. Current inventory before adding: {AmmoInventory}");
        AmmoInventory = Mathf.Clamp(AmmoInventory + amount, 0, _maxInventoryAmmo);
    }
}