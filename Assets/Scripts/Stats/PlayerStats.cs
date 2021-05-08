using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{

    private void Awake()
    {
        
        CurrentHealth = maxHealth;

        // GIVING DEFAULT WEAPON (MACE) TO PLAYER
        weapons.Add(ScriptableObject.CreateInstance<MaceWeapon>());
        weapons.Add(ScriptableObject.CreateInstance<TestStickWeapon>());

        weapons[1].Deactivate();

        currentWeapon = 0;

    }

    public override void Die()
    {
        // Death function
        Debug.Log(transform.name + " is Dead.");
    }

}
