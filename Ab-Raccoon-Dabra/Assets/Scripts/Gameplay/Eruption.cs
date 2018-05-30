using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eruption : MonoBehaviour {

	public float range;
	public float damage;
	public float sizeMultiplier;
	public float destroyTime;
	public bool iceBuff = false, stunBuff = false;
	public float buffTime;
	public LayerMask layersOfEffect;

	private GameObject particleSystemGo;
	private float distance;
	private float destroyTimer = 0;

	public void Instantiate()
	{
		particleSystemGo = GetComponentInChildren<ParticleSystem>().gameObject;
		destroyTimer = Time.time;
		gameObject.transform.localScale *= sizeMultiplier;
		particleSystemGo.transform.localScale *= sizeMultiplier;


		Collider[] enemyHits = Physics.OverlapSphere(transform.position, sizeMultiplier, layersOfEffect);
		foreach(var hit in enemyHits)
		{
			Enemy enemy = hit.GetComponentInChildren<Enemy>();
			if (!enemy)
				enemy = hit.GetComponentInParent<Enemy>();
			enemy.AddBuff(iceBuff, stunBuff, buffTime);
			enemy.GetHit(damage);

		}
		
	}

	void Update()
	{
		if (destroyTimer < Time.time - destroyTime)
			DestroyProjectile();

	}
	protected virtual void DestroyProjectile()
	{
		Destroy(gameObject);
	}


}
