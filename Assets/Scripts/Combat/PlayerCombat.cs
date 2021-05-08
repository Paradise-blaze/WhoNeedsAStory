using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerCombat : CharacterCombat
{

    [SerializeField]
    // Player Camera
    private Camera fpsCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && myStats.getCurrentWeapon().CanFire())
        {
            myStats.getCurrentWeapon().PlayAttackAnimation();
            Debug.Log(transform.name + " attacked with " + myStats.getCurrentWeapon().GetName());
            Attack();
        }

        // TODO: Create WeaponSwitchDelay function instead of CanFire
        if (Input.GetButton("Fire2") && myStats.getCurrentWeapon().CanFire())
        {
            if (myStats.getCurrentWeapon().isActive)
            {
                myStats.getCurrentWeapon().Deactivate();
            } else {
                myStats.getCurrentWeapon().Activate();
            }
        }

        // TODO: WeaponSwitchDelay
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && myStats.getCurrentWeapon().CanFire())
        {
            myStats.nextWeapon();
        }

    }
    void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, myStats.getCurrentWeapon().weaponRange))
        {
            CharacterStats targetStats = hit.transform.GetComponent<CharacterStats>();
            if (targetStats != null)
            {
                targetStats.TakeDamage(myStats.getCurrentWeapon().weaponDamage);
            }

            //Debug.Log(hit.transform.name);
        }

    }
}
