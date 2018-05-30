using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    protected Health health;
    public Weapon[] weapons;
    protected int equippedSpell = 1;

    public int EquippedSpell
    {
        get {return equippedSpell;}
        set
        { 
            if (value > weapons.Length-1 || value < 1)
                equippedSpell = 1;
            else
                equippedSpell = value;
        }
    }
  
    public void Attack()
    {
        Attack(0);
    }
    public void Attack(int equippedSpell)
    {
      weapons[equippedSpell].Attack();
    }

    public virtual void Move()
    {

    }

    public void GetHit(float dmgValue)
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
