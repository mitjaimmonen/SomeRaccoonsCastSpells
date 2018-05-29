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

	public LayerMask layersOfEffect;

	//Point of origin for instantiating projectiles or sphere checks
	protected Transform playerTrans;
	protected Transform muzzle;
	protected bool isOnCooldown = false;

	protected float fireRateTimer = -10f;

	// Use this for initialization
	protected virtual void Awake () {
		//Check for references and variables
		if (!muzzle)
		{
			foreach(var trans in transform.parent.GetComponentsInChildren<Transform>())
			{
				if (trans.gameObject.name == "muzzle" || trans.gameObject.name == "Muzzle")
					muzzle = trans;
			}
		}
		if (!muzzle)
			Debug.LogWarning("Weapon did not find muzzle.");

		playerTrans = GameObject.FindGameObjectWithTag("Player").transform;
			
	}

	public virtual void Attack()
	{
		//attack in overrides
	}

}
