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

}
