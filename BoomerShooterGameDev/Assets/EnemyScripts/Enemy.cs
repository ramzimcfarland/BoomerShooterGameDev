// This script was written based off of this Youtube tutorial: https://www.youtube.com/watch?v=Mcs7Ykxe6Ko
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            animator.SetTrigger("Die");
            Destroy(gameObject, 2f); // Destroy the enemy after 2 seconds to allow the death animation to play
        }
        else
        {
            animator.SetTrigger("Hit");
        }
    }
}

//REMINDER: edit bullet or weapon script for take damage