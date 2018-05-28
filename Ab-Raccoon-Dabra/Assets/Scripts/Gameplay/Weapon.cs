using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

	public float damage;
	[Range(0.01f,10f), Tooltip("Cooldown of each shot in seconds.")]
	public float fireRate;
	[Tooltip("Time until projectile/collisionCheck is destroyed.")]
	public float destroyTime;
	[Tooltip("Can weapon be shot continuously as autoshoot/held down.")]
	public bool isContinuous = false;


	protected float fireRateTimer = 0;

	// Use this for initialization
	void Awake () {
		//Check for references and variables
	}

	public virtual void Attack()
	{
		if (fireRateTimer > Time.time - fireRate)
			return;
		fireRateTimer = Time.time;
		//Do not attack if not enough time passed
		//Otherwise continue to attack		

		//Rest of attack in overrides
	}

}
