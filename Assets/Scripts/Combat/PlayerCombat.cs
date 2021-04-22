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
        if (Input.GetButton("Fire1") && myStats.currentWeapon.CanFire())
        {
            myStats.currentWeapon.PlayAttackAnimation();
            Debug.Log(transform.name + " attacked with " + myStats.currentWeapon.GetName());
            Attack();
        }
    }
    void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, myStats.currentWeapon.weaponRange))
        {
            CharacterStats targetStats = hit.transform.GetComponent<CharacterStats>();
            if (targetStats != null)
            {
                targetStats.TakeDamage(myStats.currentWeapon.weaponDamage);
            }

            //Debug.Log(hit.transform.name);
        }

    }
}
