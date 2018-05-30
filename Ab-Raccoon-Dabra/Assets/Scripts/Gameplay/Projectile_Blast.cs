using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Blast : Projectile {

	public float blastMultiplier;
	public ParticleSystem blastParticles;
	public float blastDamage;

	protected override void DestroyProjectile()
	{
		//Spawn explosion
		GameObject temp = Instantiate(blastParticles, transform.position, transform.rotation).gameObject;
		temp.transform.localScale *= blastMultiplier;
		Destroy(temp, 1f);
		
		Collider[] enemyHits = Physics.OverlapSphere(transform.position, blastMultiplier, layersOfEffect);
		foreach(var hit in enemyHits)
		{
			Character enemy = hit.GetComponentInChildren<Character>();
			if (!enemy)
				enemy = hit.GetComponentInParent<Enemy>();
			enemy.AddBuff(iceBuff, stunBuff, buffTime);
			enemy.GetHit(blastDamage);

		}
		base.DestroyProjectile();
	}
}
