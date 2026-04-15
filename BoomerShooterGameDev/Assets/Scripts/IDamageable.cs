using UnityEngine;

public interface IDamagable
{
    float currentHealth { get; }
    float maxHealth { get; }
    bool isDead { get; }

    void TakeDamage(float amount);
    void Heal(float amount);
}
