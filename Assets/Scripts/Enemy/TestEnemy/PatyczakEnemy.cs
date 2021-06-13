using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatyczakEnemy : Enemy
{

    public int attackDistance = 3;
    public int attackDamage = 10;
    private float nextTimeToAttack = 0f;
    public float attackRate = 1.2f;

    // Update is called once per frame
    public void Update()
    {

        if (((Player.transform.position - this.transform.position).sqrMagnitude < attackDistance*attackDistance) && CanAttack())
        {
            Attack();
        }

    }

    public bool CanAttack()
    {
        if (Time.time >= nextTimeToAttack)
        {
            nextTimeToAttack = Time.time + 1f / attackRate;
            return true;
        }
        return false;
    }

    private void Attack()
    {
        PlayerStats p = Player.transform.GetComponent<PlayerStats>();
        p.TakeDamage(attackDamage);

       // Debug.Log(this.transform.name + " Attacks");
    }


}
