using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mace Weapon", menuName = "Weapons/Mace")]
public class MaceWeapon : Weapon
{

    private Animator anim;

    public MaceWeapon()
    {
        weaponName = "Mace";
        weaponDamage = 40;
        weaponRange = 10f;
        weaponFireRate = 2f;

    }

    private void OnEnable()
    {
        anim = GameObject.Find("ModelWeaponMace").GetComponent<Transform>().GetComponent<Animator>();
    }

    public override void PlayAttackAnimation()
    {
        anim.Play("MaceWeaponAttackAnimation");
    }
}
