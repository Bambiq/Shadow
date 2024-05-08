using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public PlayerCombat combat;

    Vector2 startPos;
    private void Start()
    {
        startPos = transform.position;
    }

    public void Die()
    {
        Respawn();
    }

    public void Respawn()
    {
        transform.position = startPos;
        combat.Respaw();
    }
}
