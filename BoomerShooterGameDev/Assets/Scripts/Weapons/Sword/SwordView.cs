using UnityEngine;

public class SwordView : MonoBehaviour
{   
    [SerializeField] private Sword _sword;
    [SerializeField] private Animator _animator;
    private static readonly int AttackTrigger = Animator.StringToHash("Attack");

    void Awake()
    {
        _sword.OnFire += HandleFire;
    }
    private void OnDestroy()
    {
        _sword.OnFire -= HandleFire;
    }
    private void HandleFire()
    {
        _animator.SetTrigger(AttackTrigger);
    }
}
