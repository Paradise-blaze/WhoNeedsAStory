using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private void Awake()
    {
        
        CurrentHealth = maxHealth;

        // GIVING DEFAULT WEAPON (MACE) TO PLAYER
        currentWeapon = ScriptableObject.CreateInstance<MaceWeapon>();

    }

    public override void Die()
    {
        // Death function
        Debug.Log(transform.name + " is Dead.");
    }

}
