using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject deathParticles;
    public GameObject explosionParticles;
    public GameObject takeDamageParticles;

    public Weapon[] weapons;
    [SerializeField] protected float maxHealth;
    [FMODUnity.EventRef] public string explosionSound;
    [FMODUnity.EventRef] public string damageSound;
    [FMODUnity.EventRef] public string deathSound;

    protected int equippedSpell = 1;
    protected Health health;
    protected bool iceBuff = false, stunBuff = false;
    protected float buffTime;
    protected bool diedExploding = false;

    protected bool destroying;

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
    public bool IsAlive
    {
        get { return health.isAlive(); }
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
        if (takeDamageParticles)
        {
            Quaternion rot = transform.rotation;
            rot.y = Random.Range(0,360);
            GameObject temp = Instantiate(takeDamageParticles, transform.position, rot);
            Destroy(temp, 2f);
        }

        if (!health.isAlive())
        {
            DIE();
        }
    }
    public void GetHit(float dmgValue, bool explosion)
    {
        //take damage, stagger and such
        health.TakeDamage(dmgValue);
        if (takeDamageParticles)
        {
            Quaternion rot = transform.rotation;
            rot.y = Random.Range(0,360);
            GameObject temp = Instantiate(takeDamageParticles, transform.position, rot);
            Destroy(temp, 2f);
        }

        if (!health.isAlive())
        {
            diedExploding = explosion;
            DIE();
        }
    }
    protected virtual void DIE()
    {
        if (!destroying)
        {
            if (diedExploding)
            {
                FMODUnity.RuntimeManager.PlayOneShot(explosionSound, transform.position);
                if (explosionParticles)
                {
                    GameObject temp = Instantiate(explosionParticles, transform.position, transform.rotation);
                    Destroy(temp, 2f);
                }

            }
            else if (deathParticles)
            {
                FMODUnity.RuntimeManager.PlayOneShot(damageSound, transform.position);
                GameObject temp = Instantiate(deathParticles, transform.position, transform.rotation);
                Destroy(temp, 2f);
            }
            if (deathSound != "")
                FMODUnity.RuntimeManager.PlayOneShot(deathSound, transform.position);

            destroying = true;
            Destroy(gameObject);
        }

    }

}
