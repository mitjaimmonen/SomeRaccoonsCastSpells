using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_BasicMelee : Weapon {

	[Tooltip("How big area is affected by melee attack")]
	public float damageRadius;
	[Tooltip("Is damage check done in middle of character or in front of it. 0 affects all surroundings, 1 affects only front")]
	public float forwardMultiplier;

	[FMODUnity.EventRef] public string attackHitSound;

	// Use this for initialization
	void Start () {
		
	}
	protected override void Attack()
	{
		base.Attack();

		FMODUnity.RuntimeManager.PlayOneShot(attackSound, transform.position);

		Collider[] enemyHits = Physics.OverlapSphere(transform.position + transform.forward*forwardMultiplier, damageRadius, layersOfEffect);
			Debug.Log("BasicMelee, " + damage + ", enemyhits: " + enemyHits);
		Debug.Log(enemyHits.Length);
		foreach(var hit in enemyHits)
		{
			Character enemy = hit.GetComponentInChildren<Character>();
			if (!enemy)
				enemy = hit.GetComponentInParent<Character>();
			
			Invoke("PlayHitSound", Random.Range(0,0.1f));
			enemy.AddBuff(iceBuff, stunBuff, buffTime);
			enemy.GetHit(damage);

		}
	}

	void PlayHitSound()
	{
		FMODUnity.RuntimeManager.PlayOneShot(attackHitSound, transform.position);
	}
	
}
