using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Blast : Projectile {

	[FMODUnity.EventRef] public string blastSound;
	public float blastMultiplier;
	public ParticleSystem blastParticles;
	public float blastDamage;

	protected override void DestroyProjectile()
	{
		//Spawn explosion
		GameObject temp = Instantiate(blastParticles, transform.position, transform.rotation).gameObject;
		temp.transform.localScale *= blastMultiplier;
		Destroy(temp, 1f);

		FMODUnity.RuntimeManager.PlayOneShot(blastSound, transform.position);
		
		Collider[] enemyHits = Physics.OverlapSphere(transform.position, blastMultiplier, layersOfEffect);
		foreach(var hit in enemyHits)
		{
			Character enemy = hit.GetComponentInChildren<Character>();
			if (!enemy)
				enemy = hit.GetComponentInParent<Enemy>();
			enemy.AddBuff(iceBuff, stunBuff, buffTime);
			enemy.GetHit(blastDamage, true);

		}
		base.DestroyProjectile();
	}

	protected override void OnCollisionEnter(Collision other)
	{
		//Deal damage
		Character enemy = other.gameObject.GetComponentInChildren<Character>();
		if (!enemy)
			enemy = other.gameObject.GetComponentInParent<Character>();
		if (enemy)
		{
			enemy.AddBuff(iceBuff, stunBuff, buffTime);
			enemy.GetHit(damage, true);
			DestroyProjectile();
		}

	}
}
