using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public GameController Spawn;
    public PlayerMovement move;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate; // Limit attacks per secound
            }
        }
    }
    void Attack()
        {
            // Play an attack animation
            animator.SetTrigger("Attack");
            // Detect enemy in range of atack
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            // Damage them
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
        }
    public void TakeDamageFromEnemy(int damageAmound)
    {
        currentHealth -= damageAmound;
        
        if (currentHealth <= 0)
        {
            move.enabled = false;
            this.enabled = false;
            animator.SetBool("IsDead", true);
            Die();
        }
        healthBar.SetHealth(currentHealth);
    }

    IEnumerable Die()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }
    
    public void Respaw()
    {
        this.enabled = true;
        move.enabled = true;
        animator.SetBool("IsDead", false);
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
