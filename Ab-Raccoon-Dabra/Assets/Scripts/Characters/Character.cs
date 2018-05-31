using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Weapon[] weapons;
    [SerializeField] protected float maxHealth;


    protected int equippedSpell = 1;
    protected Health health;
    protected bool iceBuff = false, stunBuff = false;
    protected float buffTime;



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
    public float MaxHealth
    {
        get { return maxHealth; }
    }
    public float CurrentHealth
    {
        get { return health.CurrentHealth; }
    }
  
    public void Attack()
    {
        Attack(0);
    }
    public void Attack(int equippedSpell)
    {
      weapons[equippedSpell].TryAttack();
    }

    public virtual void Move()
    {

    }

    public void AddBuff(bool addIceBuff, bool addStunBuff, float time)
    {
        iceBuff = addIceBuff;
        stunBuff = addStunBuff;
        buffTime = time;
        StartCoroutine(HandleBuff(addIceBuff, addStunBuff));
        
    }
    IEnumerator HandleBuff(bool ice, bool stun)
    {
        yield return new WaitForSecondsRealtime(buffTime);
        if (ice)
            iceBuff = false;
        if (stun)
            stunBuff = false;
            
        yield break;
            
    }

    public void GetHit(float dmgValue)
    {
        //take damage, stagger and such
        health.TakeDamage(dmgValue);

        if (!health.isAlive())
        {
            DIE();
        }
    }

    protected virtual void DIE()
    {
         Destroy(gameObject);
    }

}
