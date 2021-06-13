using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName ="Inventory/Equipment")]
public class Equipment : Item
{
	public EquipmentSlot equipmentSlot;
	public MeshRenderer mesh;

	public int armorModifier;
	public int damageModifier;

	public override void Equip() {
		base.Equip();
		EquipmentManager.instance.Equip(this);
		RemoveFromInventory();
	}
}

public enum EquipmentSlot { Head, Chest, Weapon}
