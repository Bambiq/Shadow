using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //Damage to player
    public int damageAmound = 10;
    public PlayerCombat playerCombat;
    // Immnity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //Deal damage to player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            if (collision.gameObject.tag == "Player")
            {
                playerCombat.TakeDamageFromEnemy(damageAmound);
            }
        }
    }
}
