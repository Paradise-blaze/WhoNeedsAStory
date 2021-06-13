using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class Player : MonoBehaviour
{
    #region Singleton

    public static Player instance;

    void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one instance of Inventory");
            return;
        }
        instance = this;
    }

    #endregion

    public PlayerStats playerStats;

    public int currentWeapon;

    public Weapon weapon;

    [SerializeField]
    // Player Camera
    private Camera fpsCam;

	private void Start() {
        playerStats = GetComponent<PlayerStats>();
        weapon = ScriptableObject.CreateInstance<MaceWeapon>();
    }

	// Update is called once per frame
	void Update() {
        if (! (Inventory.isInventoryVisible || Inventory.isCharacterVisible)) {

            if (Input.GetButton("Fire1") && weapon.CanFire()) {
                weapon.PlayAttackAnimation();
                Debug.Log(transform.name + " attacked with " + weapon.GetName());
                Attack();
            }

            // TODO: Create WeaponSwitchDelay function instead of CanFire
            if (Input.GetButton("Fire2") && weapon.CanFire()) {
                if (weapon.isActive) {
                    weapon.Deactivate();
                } else {
                    weapon.Activate();
                }
            }


            if (Input.GetButton("E")) {
                RaycastHit hit;

                if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 3)) {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null) {
                        PickupItem();
                    }
                }
            }
        }
    }

    void PickupItem() {

	}
    void Attack() {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, weapon.weaponRange)) {
            Enemy targetStats = hit.transform.GetComponent<Enemy>();
            if (targetStats != null) {
                targetStats.TakeDamage(weapon.weaponDamage + playerStats.damage.GetValue());
            }
            //Debug.Log(hit.transform.name);
        }

    }

    public virtual void Die() {
        //When player dies showing game over screen
        //Destroy(gameObject);
        Debug.Log(transform.name + " is Dead.");
    }
}
