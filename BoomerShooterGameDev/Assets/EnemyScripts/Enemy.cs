// This script was written based off of this Youtube tutorial: https://www.youtube.com/watch?v=Mcs7Ykxe6Ko
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private Animator animator;

    private NavMeshAgent navAgent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            animator.SetTrigger("Die");
            Debug.Log("DIED");
            Destroy(gameObject, 2f);
        }
        else
        {
            animator.SetTrigger("Hit");
            Debug.Log("HIT");
        }
    }

    private void Update()
    {
        if (navAgent.velocity.magnitude > 0.1f)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}

//REMINDER: edit bullet or weapon script for take damage