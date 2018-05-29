using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Spell_Blast : Weapon_Spell {


	[Tooltip("Projectile range until destroyed")]
	public float range;
	public float projectileSpeed;
	public float projectileSizeMultiplier;
	public float projectileBlastMultiplier;
	public GameObject projectilePrefab;
	public GameObject blastPrefab;

	
	public override void Attack()
	{
		base.Attack();

		if (fireRateTimer > Time.time - fireRate)
			return;
		
		fireRateTimer = Time.time;

		
		GameObject currentProjectilego = Instantiate(projectilePrefab, muzzle.position, playerTrans.rotation);
		Projectile_Blast currentProjectile = currentProjectilego.GetComponent<Projectile_Blast>();
		currentProjectile.damage = damage;
		currentProjectile.destroyTime = destroyTime;
		currentProjectile.range = range;
		currentProjectile.speed = projectileSpeed;
		currentProjectile.sizeMultiplier = projectileSizeMultiplier;
		currentProjectile.blastMultiplier = projectileBlastMultiplier;

	}

}
