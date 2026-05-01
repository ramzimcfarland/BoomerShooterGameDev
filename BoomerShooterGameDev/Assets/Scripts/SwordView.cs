using UnityEngine;

public class SwordView : MonoBehaviour
{   
    [SerializeField] private Sword _sword;

    void Awake()
    {
        _sword.OnFire += HandleFire;
    }
    private void OnDestroy()
    {
        _sword.OnFire -= HandleFire;
    }
    private void HandleFire(){}
}
