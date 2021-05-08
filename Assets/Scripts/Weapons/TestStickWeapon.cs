using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Test Stick Weapon", menuName = "Weapons/TestStick")]
public class TestStickWeapon : Weapon
{
    public TestStickWeapon()
    {
        weaponName = "TestStick";
        weaponDamage = 1000;
        weaponRange = 1000f;
        weaponFireRate = 10f;
    }

}
