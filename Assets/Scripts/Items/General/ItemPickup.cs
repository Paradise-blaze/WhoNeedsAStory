using UnityEngine;

public class ItemPickup : Interactable
{

	public Item item;

	public override void Interact() {
		base.Interact();

		PickUp();
	}

	void PickUp() {

		Debug.Log("Picking up: " + item.name);
		bool wasPickedUp = Inventory.inventoryInstance.Add(item);
		if (wasPickedUp) {
			Destroy(gameObject);
		}
	}
}
