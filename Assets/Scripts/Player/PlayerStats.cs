using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public Stat maxHealth;
    public int currentHealth { get; private set; }
    public Stat armor;
    public Stat damage;

	private void Start() {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
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
        currentHealth = maxHealth.GetValue();
    }

    public void TakeDamage (int damage) {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentHealth <= 0) {
            Die();
        }
    }

    public virtual void Die() {

	}
}
