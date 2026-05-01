//This script was made using AI
using UnityEngine;
using System;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
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
        if (_isDead || damage <= 0f) return;

        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0f, maxHealth);
        OnDamageTaken?.Invoke(damage);
        OnHealthChanged?.Invoke(_currentHealth, maxHealth);

        if(gameObject.CompareTag("Player"))
            HUDManager.Instance?.UpdateHealth(_currentHealth); 

        Debug.Log($"{gameObject} took {damage} damage!");


        if (_currentHealth <= 0f) 
        {
            Die();
            if(gameObject.CompareTag("Player"))
                UIScreenManager.Instance?.HandlePlayerDeath();
        }
    }
    public void Heal(float amount)
    {
        if (_isDead || amount <= 0f) return;

        _currentHealth = Mathf.Clamp(_currentHealth + amount, 0f, maxHealth);
        OnHealed?.Invoke(amount);
        OnHealthChanged?.Invoke(_currentHealth, maxHealth);

        Debug.Log($"{gameObject} healed {amount} health!");
        if(gameObject.CompareTag("Player"))
        {                           
            Debug.Log("updating hud for health");
            HUDManager.Instance?.UpdateHealth(_currentHealth);
        }   
    }

    private void Die()
    {
        _isDead = true;
        OnDeath?.Invoke();
        Debug.Log($"{gameObject} fuckin' died");



        if (destroyOnDeath) Destroy(gameObject);
    }
    
}
