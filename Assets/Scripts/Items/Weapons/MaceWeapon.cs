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

    public MaceWeapon()
    {
        weaponName = "Mace";
        weaponDamage = 40;
        weaponRange = 10f;
        weaponFireRate = 2f;

    }

    private void OnEnable()
    {

        //GameObject go = Instantiate(Resources.Load("Assets/Models/WeaponModels/ModelWeaponMace.prefab", typeof(GameObject))) as GameObject;
        maceGameObject = Instantiate(AssetDatabase.LoadAssetAtPath("Assets/Models/WeaponModels/ModelWeaponMace.prefab", typeof(Object))) as GameObject;
        maceGameObject.transform.parent = Camera.main.transform;
        scale = maceGameObject.transform.lossyScale;

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
        anim.Play("MaceWeaponAttackAnimation");
    }
}
