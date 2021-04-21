using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    private void Awake()
    {
        CurrentHealth = maxHealth;
    }
    public override void Die()
    {
        // Death function
        Destroy(gameObject);
        Debug.Log(transform.name + " is Dead.");
    }
}
