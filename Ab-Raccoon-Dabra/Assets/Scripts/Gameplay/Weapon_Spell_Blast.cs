using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Spell_Blast : Weapon_Spell {

	public float blastDamage;

	[Tooltip("Projectile range until destroyed")]
	public float range;
	public float projectileSpeed;
	public float projectileSizeMultiplier;
	public float projectileBlastMultiplier;
	public GameObject projectilePrefab;

	
	protected override void Attack()
	{
		base.Attack();


		
		GameObject currentProjectilego = Instantiate(projectilePrefab, muzzle.position, characterTrans.rotation);
		Projectile_Blast currentProjectile = currentProjectilego.GetComponent<Projectile_Blast>();
		currentProjectile.damage = damage;
		currentProjectile.destroyTime = destroyTime;
		currentProjectile.range = range;
		currentProjectile.speed = projectileSpeed;
		currentProjectile.sizeMultiplier = projectileSizeMultiplier;
		currentProjectile.blastMultiplier = projectileBlastMultiplier;
		currentProjectile.blastDamage = blastDamage;
		currentProjectile.buffTime = buffTime;
		currentProjectile.stunBuff = stunBuff;
		currentProjectile.iceBuff = iceBuff;

	}

}
