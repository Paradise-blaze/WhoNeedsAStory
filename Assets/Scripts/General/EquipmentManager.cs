using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
	#region Singleton

	public static EquipmentManager instance;

	void Awake() {
		if (instance != null) {
			Debug.LogWarning("More than one instance of Inventory");
			return;
		}
		instance = this;
	}

	#endregion

	public Equipment[] currentEquipment;

	public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
	public OnEquipmentChanged onEquipmentChanged;
	public TextMeshProUGUI damageText;
	public TextMeshProUGUI armorText;

	private void Update() {
		damageText.text = Player.instance.playerStats.damage.GetValue().ToString();
		armorText.text = Player.instance.playerStats.armor.GetValue().ToString();
	}

	private void Start() {
		int numSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
		currentEquipment = new Equipment[numSlots];
	}

	public void Equip(Equipment newItem) {
		int slotId = (int)newItem.equipmentSlot;

		Equipment oldItem = null;

		if (currentEquipment[slotId] != null) {
			oldItem = currentEquipment[slotId];
			Inventory.inventoryInstance.Add(oldItem);
		}

		if(onEquipmentChanged != null) {
			onEquipmentChanged.Invoke(newItem, oldItem);
		}

		currentEquipment[slotId] = newItem;
	}

	public void Unequip (int slotIndex) {
		if (currentEquipment[slotIndex] != null) {
			Equipment oldItem = currentEquipment[slotIndex];
			Inventory.inventoryInstance.Add(oldItem);

			currentEquipment[slotIndex] = null;

			if (onEquipmentChanged != null) {
				onEquipmentChanged.Invoke(null, oldItem);
			}
		}
	}
}
