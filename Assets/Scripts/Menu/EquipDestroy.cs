using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EquipDestroy : MonoBehaviour
{

    #region Singleton

    public static EquipDestroy instance;

    void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one instance of Inventory");
            return;
        }
        instance = this;
    }

    #endregion

    public GameObject equipDestroy;

    Button[] buttons;

	private void Start() {
        buttons = equipDestroy.GetComponentsInChildren<Button>();
	}

    public void Choose(Item item) {
        equipDestroy.SetActive(true);
        buttons[0].onClick.AddListener(() => { item.Equip(); Cancel(); }); // equip
        buttons[1].onClick.AddListener(() => {Inventory.inventoryInstance.Remove(item); Cancel(); });
        buttons[2].onClick.AddListener(() => Cancel());
    }

    void Cancel() {
        equipDestroy.SetActive(false);
        buttons[0].onClick.RemoveAllListeners();
        buttons[1].onClick.RemoveAllListeners();
        buttons[2].onClick.RemoveAllListeners();
    }
}
