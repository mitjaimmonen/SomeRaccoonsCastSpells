using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Spell_Blast : Weapon_Spell {


	[Range(0.01f,10f), Tooltip("Projectile range until destroyed")]
	public float range;

	public GameObject projectilePrefab;
	public GameObject blastPrefab;

	
	public override void Attack()
	{
		base.Attack();

		
		//Instantiate projectile
		//Give projectile its variables
		//Launch projectile forward
		//Give projectile the blastPrefab

	}

}
