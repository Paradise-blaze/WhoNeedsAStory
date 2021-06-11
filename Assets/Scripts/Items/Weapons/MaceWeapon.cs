using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Mace Weapon", menuName = "Weapons/Mace")]
public class MaceWeapon : Weapon
{
    private GameObject maceGameObject;
    private Animator anim;
    private Vector3 scale;
    private Quaternion rotation;

    public MaceWeapon()
    {
        weaponName = "Mace";
        weaponDamage = 40;
        weaponRange = 10f;
        weaponFireRate = 1.2f;

    }

    private void OnEnable()
    {

        //GameObject go = Instantiate(Resources.Load("Assets/Models/WeaponModels/ModelWeaponMace.prefab", typeof(GameObject))) as GameObject;
        maceGameObject = Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Models/WeaponModels/Sword.prefab", typeof(Object))) as GameObject;
        maceGameObject.transform.parent = Camera.main.transform;
        scale = maceGameObject.transform.lossyScale;

        Quaternion target = Quaternion.Euler(60.0f, 0, 60.0f);

        // Dampen towards the target rotation
        maceGameObject.transform.rotation = Quaternion.Slerp(maceGameObject.transform.rotation, target, Time.deltaTime * 5.0f);

        anim = maceGameObject.transform.GetComponent<Animator>();

        isActive = true;
        
    }

    public override void Deactivate()
    {
        maceGameObject.transform.localScale = new Vector3(0, 0, 0);
        isActive = false;
    }

    public override void Activate()
    {
        Debug.Log(maceGameObject.transform.lossyScale);
        maceGameObject.transform.localScale = scale;
        isActive = true;
    }

    public override void PlayAttackAnimation()
    {
        anim.Play("SwordAttackAnimation");
    }
}
