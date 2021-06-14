using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public Stat maxHealth;
    public int currentHealth = 100;
    public Stat armor;
    public Stat damage;

    public HealthBar healthBar;

	private void Start() {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
        healthBar.SetMaxHealth(maxHealth.GetValue());
	}

	private void OnEquipmentChanged(Equipment newItem, Equipment oldItem) {
		if (newItem != null) {
            armor.AddModifier(newItem.armorModifier);
            damage.AddModifier(newItem.damageModifier);
        }

		if (oldItem != null) {
            armor.RemoveModifier(oldItem.armorModifier);
            damage.RemoveModifier(oldItem.damageModifier);
        }
    }

	private void Awake() {
        currentHealth = 100;
    }

    public void TakeDamage (int damage) {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        Debug.Log(currentHealth);

        if (currentHealth <= 0) {
            Die();
        }
    }

    public virtual void Die() {
        Debug.Log("Player is Dead");
	}
}
