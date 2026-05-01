// This script was written with the help of Claude AI

using System.IO;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public enum  EnemyState { Idle, Chase, Attack }
    public EnemyState currentState = EnemyState.Idle;
    [SerializeField] private WeaponCore _weapon;
    public Transform player;
    private NavMeshAgent agent;

    // Adjust as needed
    public float alertRange = 20f;
    public float sightRange = 10f;
    public float attackRange = 2f; 
    public float moveSpeed = 4f; 
    public bool isActive = false; // set to true with trigger (player enters arena or something)

    public float attackCooldown = 1.5f;
    float lastAttackTime;

    //offset for enemies chasing player
    private Vector3 offset;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        offset = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
    }

    void Update()
    {
        if (player == null) return;
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

    bool CanSeePlayer()
    {
        Vector3 eyeHeight = transform.position + Vector3.up * 1f; // adjust height
        Vector3 playerChest = player.position + Vector3.up * 1f;
        Vector3 dir = playerChest - eyeHeight;

        if (Physics.Raycast(eyeHeight, dir, out RaycastHit hit))
                return hit.collider.CompareTag("Player");
            return false;
    }

    bool CanAttack() => Time.time - lastAttackTime > attackCooldown;

    void HandleIdle(float dist)
    {
        if (!isActive) return;

        // notice player if active
        Vector3 dir = (player.position - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, dir, Time.deltaTime * 5f);
        
        // transition to chase if player is in range
        if (dist < alertRange && CanSeePlayer())
        {
             currentState = EnemyState.Chase;
        }

    }

    void HandleChase(float dist)
    {

        if (!isActive) return;

        // move toward player
        Vector3 destination = player.position + offset;
        if (agent.isOnNavMesh)
            agent.SetDestination(destination);

        //for if we want to have enemies that only chase if they can see the player, but it can lead to weird behavior where they get stuck on geometry and can't find a path to the player
        // if (CanSeePlayer())
        // {   
        //     Vector3 destination = player.position + offset;
        //     agent.SetDestination(destination);
        // }

        // if (player != null)
        // {
        //     agent.SetDestination(player.position);
        // }

        // if player is close, attack
         if (dist < attackRange)
            currentState = EnemyState.Attack;
    }

    void HandleAttack(float dist)
    {
        if (agent.isOnNavMesh)
            agent.ResetPath(); // stop moving

        // stop moving and attack
        if (dist > attackRange)
        {
            currentState = EnemyState.Chase;
            return;
        }
        if (CanAttack() && CanSeePlayer())
        {
            lastAttackTime = Time.time;
            currentState = EnemyState.Attack;
            Aim();
            _weapon.TryFire();
        }
    }
    void Aim() //rotate the MuzzleTransform to be pointing in the direciton of player
    //Used before firing
    {
        Vector3 direction = (player.position - _weapon.MuzzleTransform.position).normalized;
        _weapon.MuzzleTransform.rotation = Quaternion.LookRotation(direction);
    }
}

