using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceWeapon : Weapon
{

    public Animator anim;

    public MaceWeapon()
    {
        weaponName = "Mace";
        weaponDamage = 40;
        weaponRange = 10f;
        weaponFireRate = 1f;
    }
}
