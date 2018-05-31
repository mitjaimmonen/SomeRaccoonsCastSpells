using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_BatAttack : Weapon
{

    [Tooltip("Projectile range until destroyed")]
    public float range;
    public float projectileSpeed;
    public float projectileSizeMultiplier;
    public GameObject projectilePrefab;

    protected override void Attack()
    {
        base.Attack();

        GameObject currentProjectilego = Instantiate(projectilePrefab, muzzle.position, characterTrans.rotation);
        Projectile currentProjectile = currentProjectilego.GetComponent<Projectile>();
        currentProjectile.damage = damage;
        currentProjectile.destroyTime = destroyTime;
        currentProjectile.range = range;
        currentProjectile.speed = projectileSpeed;
        currentProjectile.sizeMultiplier = projectileSizeMultiplier;
        currentProjectile.layersOfEffect = layersOfEffect;


    }


}
