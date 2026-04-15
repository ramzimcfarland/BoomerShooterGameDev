// This script was written with the help of Claude AI

using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum  EnemyState { Idle, Chase, Attack }
    public EnemyState currentState = EnemyState.Idle;

    public Transform player;

    // Adjust as needed
    public float alertRange = 20f;
    public float sightRange = 10f;
    public float attackRange = 2f; 
    public float moveSpeed = 4f; 
    public bool isActive = false; // set to true with trigger (player enters arena or something)

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.position);

        switch (currentState)
        {
            case EnemyState.Idle: HandleIdle(dist); break;
            case EnemyState.Chase: HandleChase(dist); break;    
            case EnemyState.Attack: HandleAttack(dist); break;
        }    
    }

    public void Activate()
    {
        isActive = true;
        // Vector3 dir = (player.position - transform.position).normalized;
        // transform.forward = dir;
    }

    void HandleIdle(float dist)
    {
        if (!isActive) return;

        // notice player if active
        Vector3 dir = (player.position - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * 5f);
        
        // transition to chase if player is in range
        if (dist < alertRange)
        {
             currentState = EnemyState.Chase;
        }

    }

    void HandleChase(float dist)
    {
        // move toward player
        Vector3 dir = (player.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;

        // if player is close, attack
         if (dist < attackRange)
            currentState = EnemyState.Attack;
    }

    void HandleAttack(float dist)
    {
        // stop moving and attack
        if (dist < attackRange)
        {
            currentState = EnemyState.Attack;
            Debug.Log("Enemy Attacks!"); // replace with actual attack logic
        }
        else 
            currentState = EnemyState.Chase;
    }
}
