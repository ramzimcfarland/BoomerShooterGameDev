using UnityEngine;

public class EnemyMeleeWeaponView : MonoBehaviour
{   
    [SerializeField] private EnemyMeleeWeapon _weapon;
    [SerializeField] private Animator _animator;
    private static readonly int AttackTrigger = Animator.StringToHash("Attack");

    void Awake()
    {
        _weapon.OnFire += HandleFire;
    }
    private void OnDestroy()
    {
        _weapon.OnFire -= HandleFire;
    }
    private void HandleFire()
    {
        _animator.SetTrigger(AttackTrigger);
    }
}
