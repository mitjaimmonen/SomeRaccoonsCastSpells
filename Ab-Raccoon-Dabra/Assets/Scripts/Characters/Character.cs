using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    Health health;
    Weapon[] weapons;
    int equippedSpell;

  
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
    
    void GetHit()
    {
        //take damage, stagger and such
    }

    void DIE()
    {

    }
	
}
