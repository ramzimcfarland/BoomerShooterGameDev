using UnityEngine;
using System;

public abstract class Health : Monobehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    [SerializeField] private bool destroyOnDeath = false;

    
    public event Action OnDeath;
    public event Action<float> OnDamageTaken;
    public event Action<float, float> OnHealthChanged;
    public event Action<float> OnHealed;

    private float _currentHealth;
    private bool _isDead;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => maxHealth;
    public bool IsDead => _isDead;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        
    }
}
