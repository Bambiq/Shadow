using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Enemy health
    public int maxHealth;
    public int currentHealth;

    public GameObject EnemyBox;

    public Animator animator;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Taking damage from player
    public void TakeDamage(int damage)
    {
        // Taking damage
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Death animation
        animator.SetBool("IsDead", true);
        // Turn evry collider on enemy and enemy itself
        foreach (var Colliders in gameObject.GetComponents<Collider2D>())
        {
            Colliders.enabled = false;
        }
        GameObject.Find("Hitbox").GetComponent<BoxCollider2D>().enabled = false; // Disable Colliders from Hitbox object
        this.enabled = false;
    }
}
