using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_BasicMelee : Weapon {

	[Tooltip("How big area is affected by melee attack")]
	public float damageRadius;
	[Tooltip("Is damage check done in middle of character or in front of it. 0 affects all surroundings, 1 affects only front")]
	public float forwardMultiplier;

	// Use this for initialization
	void Start () {
		
	}
	protected override void Attack()
	{
		base.Attack();


		Collider[] enemyHits = Physics.OverlapSphere(transform.position + transform.forward*forwardMultiplier, damageRadius, layersOfEffect);
			Debug.Log("BasicMelee, " + damage + ", enemyhits: " + enemyHits);
		Debug.Log(enemyHits.Length);
		foreach(var hit in enemyHits)
		{
			Character enemy = hit.GetComponentInChildren<Character>();
			if (!enemy)
				enemy = hit.GetComponentInParent<Character>();
			
			enemy.AddBuff(iceBuff, stunBuff, buffTime);
			enemy.GetHit(damage);

		}

		//Start Coroutine for the time of destroyTime
		//Sphere check for enemy
		//Give damage to affected
		//End coroutine after destroyTimer is full

	}
	
}
