using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float destroyTime;
	public float range;
	public float damage;
	public float speed;
	public float sizeMultiplier;
	public LayerMask layersOfEffect;
	
	public bool iceBuff = false, stunBuff = false;
	public float buffTime;
	private GameObject particleSystemGo;
	private Vector3 startPos;
	private float distance;
	private float destroyTimer = 0;

	void Start()
	{
		particleSystemGo = GetComponentInChildren<ParticleSystem>().gameObject;
		startPos = transform.position;
		destroyTimer = Time.time;
		gameObject.transform.localScale *= sizeMultiplier;
		particleSystemGo.transform.localScale *= sizeMultiplier;
	}

	void Update()
	{
		distance = (transform.position - startPos).magnitude;
		if ((distance > range && range != 0) || destroyTimer < Time.time - destroyTime)
			DestroyProjectile();

		transform.position += transform.forward * speed * Time.deltaTime;
	}

	void OnCollisionEnter(Collision other)
	{
		//Deal damage
		Debug.Log("Collision");
		Enemy enemy = other.gameObject.GetComponentInChildren<Enemy>();
		if (!enemy)
			enemy = other.gameObject.GetComponentInParent<Enemy>();
		if (enemy)
		{
			enemy.GetHit(damage);
			DestroyProjectile();
		}

	}

	protected virtual void DestroyProjectile()
	{
		Destroy(gameObject);
	}

}
