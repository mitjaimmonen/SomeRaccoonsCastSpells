using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Blast : Projectile {

	public float blastMultiplier;
	public ParticleSystem blastParticles;

	protected override void DestroyProjectile()
	{
		//Spawn explosion
		GameObject temp = Instantiate(blastParticles, transform.position, transform.rotation).gameObject;
		temp.transform.localScale *= blastMultiplier;
		base.DestroyProjectile();
	}
}
