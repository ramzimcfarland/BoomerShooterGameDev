using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Instance;

    public TMP_Text HealthText;
    public TMP_Text AmmoText;

    // written with Claude AI so UI elements don't destroy on load
    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return;}
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateHealth(float newHealth)
    {
        HealthText.text = "Health: " + newHealth.ToString();
    }

    public void UpdateAmmo(int newAmmo, int magazineSize)
    {
        //(PlayerWeaponManager.Instance.CurrentWeapon is RangedWeaponCore ranged ? ranged.MagazineSize.ToString() : "N/A")
        AmmoText.text = "Ammo: " + newAmmo.ToString() + " / " + magazineSize;
    }

    public void SetAmmoVisible(bool visible)
    {
        AmmoText.gameObject.SetActive(visible);
    }
}
