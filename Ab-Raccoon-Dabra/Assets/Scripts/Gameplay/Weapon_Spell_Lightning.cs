using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
	Check all affected enemies here
	Then create lightning visuals and deal damage on enemies

 */


public class Weapon_Spell_Lightning : Weapon_Spell {

	[Tooltip("Amount of enemies the lightning can affect")]
	public float hops;
	[Tooltip("Radius check if unaffected enemies nearby")]
	public float hopRadius;
	[Range(0.05f,1f), Tooltip("How much hopRadius should decrease after each hop. 1 means not at all."),]
	public float radiusMultiplier;

	// Use this for initialization
	void Start () {
		
	}
	
	public override void Attack()
	{
		base.Attack();

		
		//Check all affected enemies with sphere checks
		//Deal damage on enemies
		//Spawn visuals

	}
}
