using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    public Button actionButton;

    public void AddItem(Item newItem) {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        actionButton.interactable = true;
	}

    public void ClearSlot() {
        item = null;

        icon.enabled = false;
        actionButton.interactable = false;
    }

    public void OnActionButton() {
        EquipDestroy.instance.Choose(item);
	}
}
