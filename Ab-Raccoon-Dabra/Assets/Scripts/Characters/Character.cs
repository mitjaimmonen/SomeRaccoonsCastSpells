using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    protected Health health;
    protected Weapon[] weapons;
    protected int equippedSpell;


    void Attack()
    {
        Attack(0);
    }

    void Attack(int equippedSpell)
    {
        //weapons[equippedSpell].attack;
    }

    public virtual void Move()
    {

    }

    void GetHit(float dmgValue)
    {
        //take damage, stagger and such
        health.TakeDamage(dmgValue);
    }

    protected virtual void DIE()
    {
        if (!health.isAlive())
        {
            Destroy(gameObject);
        }

    }

}
