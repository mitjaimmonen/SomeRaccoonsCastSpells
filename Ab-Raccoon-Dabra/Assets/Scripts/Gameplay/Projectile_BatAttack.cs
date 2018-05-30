using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_BatAttack : Weapon
{

    [Tooltip("Projectile range until destroyed")]
    public float range;
    public float projectileSpeed;
    public float projectileSizeMultiplier;
    public GameObject projectilePrefab;

    protected override void Awake()
    {

        if (!muzzle)
        {
            foreach (var trans in transform.parent.GetComponentsInChildren<Transform>())
            {
                if (trans.gameObject.name == "muzzle" || trans.gameObject.name == "Muzzle")
                    muzzle = trans;
            }
        }
        if (!muzzle)
            Debug.LogWarning("Weapon did not find muzzle.");

        playerTrans = transform.parent.GetComponentInParent<Transform>();

    }
    public override void Attack()
    {
        base.Attack();

        if (fireRateTimer > Time.time - fireRate)
            return;

        fireRateTimer = Time.time;

        GameObject currentProjectilego = Instantiate(projectilePrefab, muzzle.position, playerTrans.rotation);
        Projectile currentProjectile = currentProjectilego.GetComponent<Projectile>();
        currentProjectile.damage = damage;
        currentProjectile.destroyTime = destroyTime;
        currentProjectile.range = range;
        currentProjectile.speed = projectileSpeed;
        currentProjectile.sizeMultiplier = projectileSizeMultiplier;


    }
}
