// script written at the first development, no used much in our implementation
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private EnemyManager enemyManager;
    private Health _health;
    private Animator animator;
    private NavMeshAgent navAgent;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.OnDamageTaken += HandleDamageTaken;
        _health.OnDeath += HandleDeath;
        enemyManager = GetComponentInParent<EnemyManager>();
    }
    private void OnDestroy()
    {
        _health.OnDamageTaken -= HandleDamageTaken;
        _health.OnDeath -= HandleDeath;
    }

    private void HandleDamageTaken(float damage)
    {
        Debug.Log($"Enemy took {damage} damage!");
    }

    private void HandleDeath()
    {
        enemyManager?.HandleEnemyDeath();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }


    private void Update()
    {
        if (navAgent.velocity.magnitude > 0.1f)
        {
            //animator.SetBool("IsWalking", true);
        }
        else
        {
            //animator.SetBool("IsWalking", false);
        }
    }
}

//REMINDER: edit bullet or weapon script for take damage