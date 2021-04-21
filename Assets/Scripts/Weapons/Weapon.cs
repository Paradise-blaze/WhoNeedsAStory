using UnityEngine;

public class Weapon
{
    public string weaponName;
    public int weaponDamage;
    public float weaponRange;

    // Smaller -> slower
    public float weaponFireRate;

    private float nextTimeToFire = 0f;


    public string GetName() { return weaponName; }
    public int GetDamage() { return weaponDamage; }
    public float GetRange() { return weaponRange; }
    public float GetNextTimeToFire() { return nextTimeToFire; }

    public bool CanFire()
    {
        if (Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / weaponFireRate;
            return true;
        }
        return false;
    }

}
