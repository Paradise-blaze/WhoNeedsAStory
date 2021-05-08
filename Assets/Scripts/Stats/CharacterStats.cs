using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Divide class into PlayerStats and EnemyStats
public class CharacterStats : MonoBehaviour
{

    public int maxHealth = 100;
    public int CurrentHealth { get; set; }

    public Stat damage;

    public int currentWeapon;

    public List<Weapon> weapons = new List<Weapon>();

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(CurrentHealth <= 0)
        {
            Die();
        }

    }

    public virtual void Die()
    {
        // TODO: Death function
        //Destroy(gameObject);
        Debug.Log(transform.name + " is Dead.");
    }

    // TEST METHOD
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public Weapon getCurrentWeapon()
    {
        return weapons[currentWeapon];
    }

    public void nextWeapon()
    {

        getCurrentWeapon().Deactivate();

        if (currentWeapon == weapons.Count - 1)
        {
            currentWeapon = 0;
        }
        else
        {
            ++currentWeapon;
        }

        getCurrentWeapon().Activate();

    }

}
