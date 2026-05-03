using UnityEngine;
public enum DamageType { Melee, Ranged }
public interface IDamageable
{
    float CurrentHealth { get; }
    float MaxHealth { get; }
    bool IsDead { get; }

    void TakeDamage(float amount, DamageType damageType);
    void Heal(float amount);
}
