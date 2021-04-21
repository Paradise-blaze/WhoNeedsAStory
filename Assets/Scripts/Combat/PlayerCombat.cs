using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerCombat : CharacterCombat
{

    private Animator anim;

    [SerializeField]
    private Camera fpsCam;

    // THIS SHOULD BE IN WEAPON CLASS SMH
    public Transform mace;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && myStats.currentWeapon.CanFire())
        {
            // THIS SHOULD BE IN ANOTHER PLACE
            anim = mace.GetComponent<Animator>();
            anim.Play("MaceWeaponAttackAnimation");
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
