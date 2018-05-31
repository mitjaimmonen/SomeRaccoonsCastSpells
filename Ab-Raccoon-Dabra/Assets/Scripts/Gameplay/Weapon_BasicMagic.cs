using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_BasicMagic : Weapon {


	[Tooltip("Projectile range until destroyed")]
	public float range;
	public float projectileSpeed;

	[Tooltip("ParticleSystem has default size, this multiplies it.")]
	public float projectileSizeMultiplier;
	[Tooltip("The projectile object that will be shot")]
	public GameObject projectilePrefab;
	[Tooltip("Projectile spawns effect on destroy, how big should this effect be.")]
	public float projectileDestroyEffectMultiplier;

	protected override void Attack()
	{
		base.Attack();
		
		GameObject currentProjectilego = Instantiate(projectilePrefab, muzzle.position, characterTrans.rotation);
		Projectile currentProjectile = currentProjectilego.GetComponent<Projectile>();
		FMODUnity.RuntimeManager.PlayOneShot(attackSound, transform.position);
		currentProjectile.damage = damage;
		currentProjectile.destroyTime = destroyTime;
		currentProjectile.range = range;
		currentProjectile.speed = projectileSpeed;
		currentProjectile.sizeMultiplier = projectileSizeMultiplier;
		currentProjectile.iceBuff = iceBuff;
		currentProjectile.stunBuff = stunBuff;
		currentProjectile.buffTime = buffTime;
		currentProjectile.destroyEffectMultiplier = projectileDestroyEffectMultiplier;

	}
}
