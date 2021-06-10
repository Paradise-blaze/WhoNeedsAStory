using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerStats))]
public class Player : MonoBehaviour
{

    PlayerStats playerStats;

    public int currentWeapon;

    public List<Weapon> weapons = new List<Weapon>();

    [SerializeField]
    // Player Camera
    private Camera fpsCam;

    [SerializeField]
    public static Player playerObject;

	private void Start() {
        playerStats = GetComponent<PlayerStats>();
        playerObject = this;
	}

	// Update is called once per frame
	void Update() {
        if (Input.GetButton("Fire1") && getCurrentWeapon().CanFire()) {
            getCurrentWeapon().PlayAttackAnimation();
            Debug.Log(transform.name + " attacked with " + getCurrentWeapon().GetName());
            Attack();
        }

        // TODO: Create WeaponSwitchDelay function instead of CanFire
        if (Input.GetButton("Fire2") && getCurrentWeapon().CanFire()) {
            if (getCurrentWeapon().isActive) {
                getCurrentWeapon().Deactivate();
            } else {
                getCurrentWeapon().Activate();
            }
        }

        // TODO: WeaponSwitchDelay
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && getCurrentWeapon().CanFire()) {
            nextWeapon();
        } else if (Input.GetAxis("Mouse ScrollWheel") < 0f && getCurrentWeapon().CanFire()) {
            prevWeapon();
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

    void PickupItem() {

	}
    void Attack() {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, getCurrentWeapon().weaponRange)) {
            Enemy targetStats = hit.transform.GetComponent<Enemy>();
            if (targetStats != null) {
                targetStats.TakeDamage(getCurrentWeapon().weaponDamage + playerStats.damage.GetValue());
            }

            //Debug.Log(hit.transform.name);
        }

    }

    public virtual void Die() {
        //When player dies showing game over screen
        //Destroy(gameObject);
        Debug.Log(transform.name + " is Dead.");
    }

    public Weapon getCurrentWeapon() {
        return weapons[currentWeapon];
    }

    public void nextWeapon() {

        getCurrentWeapon().Deactivate();

        if (currentWeapon == weapons.Count - 1) {
            currentWeapon = 0;
        } else {
            ++currentWeapon;
        }

        getCurrentWeapon().Activate();

    }
    public void prevWeapon() {

        getCurrentWeapon().Deactivate();

        if (currentWeapon == 0) {
            currentWeapon = weapons.Count - 1;
        } else {
            --currentWeapon;
        }

        getCurrentWeapon().Activate();

    }

    private void Awake() {


        // GIVING DEFAULT WEAPON (MACE) TO PLAYER
        weapons.Add(ScriptableObject.CreateInstance<MaceWeapon>());
        weapons.Add(ScriptableObject.CreateInstance<TestStickWeapon>());

        weapons[1].Deactivate();

        currentWeapon = 0;

    }
}
