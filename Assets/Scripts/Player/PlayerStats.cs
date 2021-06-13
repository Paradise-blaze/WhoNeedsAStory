using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public Stat maxHealth;
    public int currentHealth = 100;
    public Stat armor;
    public Stat damage;

	private void Awake() {
        currentHealth = 100;
    }

    public void TakeDamage (int damage) {
        //damage -= armor.GetValue();
        //damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;

        Debug.Log(currentHealth);

        if (currentHealth <= 0) {
            Die();
        }
    }

    public virtual void Die() {
        Debug.Log("Player is Dead");
	}
}
