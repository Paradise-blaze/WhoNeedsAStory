using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	#region Singleton

	public static Inventory inventoryInstance;

	void Awake() {
		if (inventoryInstance != null) {
			Debug.LogWarning("More than one instance of Inventory");
			return;
		}
		inventoryInstance = this;	
	}

	#endregion

	public GameObject inventoryPanel;
	public GameObject characterPanel;

	public static bool isInventoryVisible = false;
	public static bool isCharacterVisible = false;

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;


	public int space = 20;

	public List<Item> items = new List<Item>();

	private void Update() {
		if (isInventoryVisible || isCharacterVisible) {
			Cursor.lockState = CursorLockMode.None;
		} else {
			Cursor.lockState = CursorLockMode.Locked;
		}

		if (Input.GetButtonDown("I")) {
				inventoryPanel.SetActive(!inventoryPanel.activeSelf);
				isInventoryVisible = !isInventoryVisible;
		}

		if (Input.GetButtonDown("C")) {
				characterPanel.SetActive(!characterPanel.activeSelf);
				isCharacterVisible = !isCharacterVisible;
		}
	}

	public bool Add (Item item) {
		if (!item.isDefaultItem) {
			if (items.Count >= space) {
				Debug.Log("Not enough space");
				return false;
			}
			items.Add(item);

			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke();
		}
		onItemChangedCallback();
		return true;
	}

	public void Remove (Item item) {
		items.Remove(item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}
}
