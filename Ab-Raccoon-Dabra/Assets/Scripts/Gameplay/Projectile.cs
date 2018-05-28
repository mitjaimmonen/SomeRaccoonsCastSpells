using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float destroyTime;
	public float range;
	public float damage;

	private Vector3 startPos;
	private float distance;
	private float destroyTimer = 0;



	void Update()
	{
		
		if (distance > range || destroyTimer < Time.time - destroyTime)
			DestroyProjectile();
	}

	void OnCollisionEnter()
	{
		//Deal damage
		DestroyProjectile();
	}

	void DestroyProjectile()
	{
		//Destroy
	}

}
